using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Colegio.Util
{
    public class RestConfiguration
    {
        #region Singleton Pattern

        private static volatile RestConfiguration instance;
        private static readonly object sync = new Object();

        /// <summary>
        /// Referencia a la única instancia
        /// </summary>
        public static RestConfiguration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (sync)
                    {
                        if (instance == null)
                        {
                            instance = new RestConfiguration();
                        }
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        #region Properties

        public WebHttpBehavior WebHttpBehavior { get; set; }

        public WebHttpBinding WebHttpBinding { get; set; }

        public WebHttpBinding WebHttpsBinding { get; set; }

        #endregion Properties

        #region Constructor

        public RestConfiguration()
        {
            WebHttpBehavior = new WebHttpBehavior()
            {
                HelpEnabled = true,
                DefaultOutgoingResponseFormat = WebMessageFormat.Json
            };

            WebHttpBinding = new WebHttpBinding()
            {
                Namespace = "Colegio",
                TransferMode = TransferMode.Streamed,
                MaxReceivedMessageSize = long.MaxValue,
            };

            WebHttpsBinding = new WebHttpBinding()
            {
                Namespace = "Colegio",
                TransferMode = TransferMode.Streamed,
                MaxReceivedMessageSize = long.MaxValue,
                Security = new WebHttpSecurity() { Mode = WebHttpSecurityMode.Transport }
            };

            WebHttpBinding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
            WebHttpsBinding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
        }

        #endregion Constructor
    }

    /// <summary>
    /// Configuracion basica de servicio Rest
    /// </summary>
    public class BasicRest
    {
        #region Public

        public static void Configure(ServiceConfiguration config)
        {
            #region Endpoint

            //HTTP
            foreach (ServiceEndpoint endpoint in config.EnableProtocol(RestConfiguration.Instance.WebHttpBinding))
            {
                endpoint.Behaviors.Add(RestConfiguration.Instance.WebHttpBehavior);
                ServiceMetadataBehavior smb = GetBehavior<ServiceMetadataBehavior>(config);
                smb.HttpGetEnabled = true;
            }

            //HTTPS
            foreach (ServiceEndpoint endpoint in config.EnableProtocol(RestConfiguration.Instance.WebHttpsBinding))
            {
                endpoint.Behaviors.Add(RestConfiguration.Instance.WebHttpBehavior);
                ServiceMetadataBehavior smb = GetBehavior<ServiceMetadataBehavior>(config);
                smb.HttpsGetEnabled = true;
            }

            #endregion Endpoint

            #region Behaviors

            ServiceMetadataBehavior meta = GetBehavior<ServiceMetadataBehavior>(config);
            meta.HttpGetEnabled = true;

            ServiceDebugBehavior debug = GetBehavior<ServiceDebugBehavior>(config);
            debug.IncludeExceptionDetailInFaults = true;
            debug.HttpHelpPageEnabled = true;

            #endregion Behaviors
        }

        #endregion Public

        #region Protected

        /// <summary>
        /// Obtiene el comportamiento solicitado de la configuracion de un servicio
        /// si no existe el comportamiento entonces se crea uno nuevo
        /// </summary>
        /// <typeparam name="T">Tipo de comportamiento</typeparam>
        /// <param name="config">Configuracion del servicio</param>
        /// <returns>Comportamiento solicitado</returns>
        protected static T GetBehavior<T>(ServiceConfiguration config) where T : IServiceBehavior, new()
        {
            T behavior = config.Description.Behaviors.Find<T>();
            if (behavior == null)
            {
                behavior = new T();
                config.Description.Behaviors.Add(behavior);
            }
            return behavior;
        }

        #endregion Protected
    }
}