using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UBSInterfaceToolkit
{
    public class EndPoint
    {
        public const string CONTENT_TYPE    = "Content-Type",
                            APPLICATION     = "application/json",
                            AUTHORIZATION   = "Authorization",
                            BEARER          = "Bearer ",
                            ACCESS_TOKEN    = "access_token",
                            NO_CONTENT      = "No content returned",
                            NOT_SUPPORTED   = "Integration type not supported";

        private static RestClient ConstructRestClient(string _ubsResource)
        {
            RestClientOptions urlOutboudInterface = new RestClientOptions(_ubsResource)
            {
                DisableCharset = true,
                Timeout = TimeSpan.FromMinutes(10)
            };
            RestClient postUrl = new RestClient(urlOutboudInterface);

            return postUrl;
        }

        private static RestRequest ConstructRestRequest(string _ressourceRequest, string _endpoint, string _bearer)
        {
            RestRequest request = new RestRequest(_ressourceRequest + _endpoint, Method.Post);
            request.AddHeader(AUTHORIZATION, BEARER + _bearer);
            request.AddHeader(CONTENT_TYPE, APPLICATION);

            return request;
        }

       

        public static object[] BuildRequest(string _ubsResource, string _ressourceRequest, string _endpoint, string _bearer, ArrayList _objectFormD365, int _integrationType,int _debugMode)
        {
            RestClient  restClient  = EndPoint.ConstructRestClient(_ubsResource);
            RestRequest restRequest = EndPoint.ConstructRestRequest(_ressourceRequest, _endpoint, _bearer);
            int         statusCode  = 0;
            string      message     = string.Empty;
            var         response    = (StatusCode: HttpStatusCode.OK, Content: (object)null);

            switch (_integrationType)
            {
                case 0:
                    List<FinancialDimensionInterface> financialDimensionInterfaces =
                        OutboundInterfaceListBuilder.ConstructFinancialDimensionList(_objectFormD365);

                    response = Post<List<FinancialDimensionInterface>, object>
                        (restClient, restRequest, financialDimensionInterfaces,_debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;

                case 1:
                    List<FinancialDimensionLegalEntityInterface> financialDimensionLEgalEntityInterface =
                            OutboundInterfaceListBuilder.ConstructFinancialDimensionLegalEntityList(_objectFormD365);

                    response = Post<List<FinancialDimensionLegalEntityInterface>, object>
                        (restClient, restRequest, financialDimensionLEgalEntityInterface, _debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;
                case 2:
                    VendorInvoiceInterface vendorInvoice = OutboundInterfaceListBuilder.ConstructVendorInvoiceList(_objectFormD365);
                    
                    response = Post<VendorInvoiceInterface, object>
                        (restClient, restRequest, vendorInvoice, _debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;

                    break;
                case 3:
                    List<VendorInterface> vendorInterface =
                            OutboundInterfaceListBuilder.ConstructVendorList(_objectFormD365);

                    response = Post<List<VendorInterface>, object>
                        (restClient, restRequest, vendorInterface, _debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;
                case 4 :
                    AccrualInterface accrualInterface = OutboundInterfaceListBuilder.ConstructAccrualList(_objectFormD365);

                    response = Post<AccrualInterface, object>
                        (restClient, restRequest, accrualInterface, _debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;
                case 5:
                    StockInterface stockInterface = OutboundInterfaceListBuilder.ConstructStockList(_objectFormD365);

                    response = Post<StockInterface,object>
                        (restClient,restRequest,stockInterface, _debugMode);

                    statusCode = ((int)response.StatusCode);
                    message = response.Content != null ? JsonConvert.SerializeObject(response.Content) : NO_CONTENT;
                    break;
                default:
                    message = NOT_SUPPORTED;
                    break;
            }
            return new object[] { statusCode, message };
        }

        public static (HttpStatusCode StatusCode, TResponse Content) Post<TRequest, TResponse>
                                            (RestClient _client, RestRequest _request, TRequest data,int _debugMode =0)
        {
            string jsonBody = JsonConvert.SerializeObject(data);
            RestResponse response = new RestResponse();
            _request.AddParameter(APPLICATION, jsonBody, ParameterType.RequestBody);
            TResponse content;

            if (_debugMode == 0)
            { 
                response = _client.Execute(_request);
                content = JsonConvert.DeserializeObject<TResponse>(response.Content);
            }
            else
            {
                content = JsonConvert.DeserializeObject<TResponse>(jsonBody);
            }
            
            return (response.StatusCode, content);
        }
    }
}
