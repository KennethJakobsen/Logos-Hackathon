# Gateway.ApiClient.Api.GatewayApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreatMenuItem**](GatewayApi.md#creatmenuitem) | **POST** /Menu/{id} |  |
| [**GetAlleMenuItems**](GatewayApi.md#getallemenuitems) | **GET** /Menu |  |

<a id="creatmenuitem"></a>
# **CreatMenuItem**
> void CreatMenuItem (int id, CreateMenuItemRequest createMenuItemRequest)



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;
using Gateway.ApiClient.Model;

namespace Example
{
    public class CreatMenuItemExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new GatewayApi(httpClient, config, httpClientHandler);
            var id = 56;  // int | 
            var createMenuItemRequest = new CreateMenuItemRequest(); // CreateMenuItemRequest | 

            try
            {
                apiInstance.CreatMenuItem(id, createMenuItemRequest);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GatewayApi.CreatMenuItem: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreatMenuItemWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    apiInstance.CreatMenuItemWithHttpInfo(id, createMenuItemRequest);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling GatewayApi.CreatMenuItemWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **int** |  |  |
| **createMenuItemRequest** | [**CreateMenuItemRequest**](CreateMenuItemRequest.md) |  |  |

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getallemenuitems"></a>
# **GetAlleMenuItems**
> List&lt;MenuItem&gt; GetAlleMenuItems ()



### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using Gateway.ApiClient.Api;
using Gateway.ApiClient.Client;
using Gateway.ApiClient.Model;

namespace Example
{
    public class GetAlleMenuItemsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            // create instances of HttpClient, HttpClientHandler to be reused later with different Api classes
            HttpClient httpClient = new HttpClient();
            HttpClientHandler httpClientHandler = new HttpClientHandler();
            var apiInstance = new GatewayApi(httpClient, config, httpClientHandler);

            try
            {
                List<MenuItem> result = apiInstance.GetAlleMenuItems();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling GatewayApi.GetAlleMenuItems: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAlleMenuItemsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    ApiResponse<List<MenuItem>> response = apiInstance.GetAlleMenuItemsWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling GatewayApi.GetAlleMenuItemsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;MenuItem&gt;**](MenuItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

