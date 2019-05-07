
--Validar si una tabla existe o ya esta creada
IF OBJECT_ID (N'USUARIOS', N'U') IS NULL
	PRINT('NO EXISTE');
	--CREAR CUANDO LA TABLA NO EXISTE
ELSE
BEGIN
	PRINT('EXISTE');
	--NO HACER NADA
END;




--Primos
---------------------------------------------------------------------------------------------------------
BEGIN TRY
	DECLARE  @i_Inicio INT = 1,
			 @i_Final INT = 100;
	DECLARE  @i_Mitad INT = CEILING((@i_Final - @i_Inicio + 1) / 2.0);

	WITH temp AS
	(
		SELECT  tmp.thing1
		FROM        (VALUES (0), (0), (0), (0), (0), (0), (0), (0), (0), (0)) tmp(thing1)
	), filas AS
	(
		SELECT  0 AS [thing2]
		FROM        temp t1
		CROSS JOIN temp t2
		CROSS JOIN temp t3
	), base AS
	(
		SELECT  TOP( CONVERT( INT, CEILING(SQRT(@i_Final)) ) )
				ROW_NUMBER() OVER (ORDER BY (SELECT 1)) AS [num]
		FROM        filas s1
		CROSS JOIN  filas s2
	), Base_I AS
	(
		SELECT  TOP (@i_Mitad)
				(ROW_NUMBER() OVER (ORDER BY (SELECT 1)) * 2) + 
					(@i_Inicio - 1 - (@i_Inicio%2)) AS [num]
		FROM        base b1
		CROSS JOIN  base b2
	),Base_P AS
	(
		SELECT  [num]
		FROM        base b3
		WHERE   b3.[num] > 4
		AND     b3.[num] % 2 <> 0
		AND     b3.[num] % 3 <> 0
	)


	SELECT  numbers.[num] AS [Primo]
	FROM        (VALUES (2), (3)) numbers(num)
	WHERE   numbers.[num] >= @i_Inicio
	UNION ALL
	SELECT  n.[num] AS [Primo]
	FROM        Base_I n
	WHERE   n.[num] BETWEEN 5 AND @i_Final
	AND     n.[num] % 3 <> 0
	AND     NOT EXISTS (SELECT *
						FROM Base_P d
						WHERE d.[num] <> n.[num]
						AND n.[num] % d.[num] = 0
						);
END TRY
BEGIN CATCH
	print('Ha ocurrido un error');
END CATCH;