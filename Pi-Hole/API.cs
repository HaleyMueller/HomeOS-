using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pi_Hole
{
    public static class API
    {
        public static string URL = "http://192.168.0.26/admin/api.php";
        public static string TOKEN = "344d14ed3488954ecbf30fe9460900e6198b0893c802d76a9477c4f8962c3f8b";

        public static Models.TypeModel GetType()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "type",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TypeModel>(val);

                return obj;
            }
            catch { }
            return new Models.TypeModel();
        }

        public static Models.VersionModel GetVersion()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "version",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.VersionModel>(val);

                return obj;
            }
            catch { }
            return new Models.VersionModel();
        }

        public static Models.SummaryRaw GetSummaryRaw()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "summaryRaw",
                UseEquals = false
            });
            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.SummaryRaw>(val);

                return obj;
            }
            catch { }
            return new Models.SummaryRaw();
        }

        public static Models.OverTimeData10MinsModel GetOverTimeData10Mins()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "overTimeData10mins",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.OverTimeData10MinsModel>(val);

                return obj;
            }
            catch { }
            return new Models.OverTimeData10MinsModel();
        }

        public static Models.TopItemsModel GetTopItems()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "topItems",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                val = Regex.Replace(val, ",?\"[^\"]+\":[[]]", "");
                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.TopItemsModel>(val);

                return obj;
            }
            catch { }
            return new Models.TopItemsModel();
        }

        public static Models.GetQuerySourcesModel GetQuerySources()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "getQuerySources",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.GetQuerySourcesModel>(val);

                return obj;
            }
            catch { }
            return new Models.GetQuerySourcesModel();
        }

        public static Models.GetForwardDestinationsModel GetForwardDestinations()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "getForwardDestinations",
                UseEquals = false
            });

            try
            {

                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.GetForwardDestinationsModel>(val);

                return obj;
            }
            catch { }

            return new Models.GetForwardDestinationsModel();
        }

        public static Models.GetQueryTypesModel GetQueryTypes()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "getQueryTypes",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.GetQueryTypesModel>(val);

                return obj;
            }
            catch
            {

            }

            return new Models.GetQueryTypesModel();
        }

        public static Models.GetAllQueriesModel GetAllQueries()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "getAllQueries",
                UseEquals = false
            });

            var ret = new Models.GetAllQueriesModel();

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.GetAllQueriesModel.DataModel>(val);
                ret.Data = obj;
            }
            catch
            {

            }

            
            
            ret.UpdateSerializedModel();

            return ret;
        }

        public static Models.EnableModel Enable()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "enable",
                UseEquals = false
            });

            try
            {
                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.EnableModel>(val);

                return obj;
            }
            catch
            {

            }
            return new Models.EnableModel();
        }

        public static Models.DisableModel Disable()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "disable",
                UseEquals = false
            });

            try
            {

                var val = webClient.Post(URL, queryParms, null, null).Result;

                var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.DisableModel>(val); 
                return obj;
            }
            catch
            {

            }

            return new Models.DisableModel();
        }

        public static string GetLastBlockedDomain()
        {
            Utilities.HTTPWebClient webClient = new Utilities.HTTPWebClient();

            var queryParms = new List<Utilities.HTTPWebClient.QueryParm>();

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "auth",
                Value = TOKEN
            });

            queryParms.Add(new Utilities.HTTPWebClient.QueryParm()
            {
                Key = "recentBlocked",
                UseEquals = false
            });

            try
            {

                var val = webClient.Post(URL, queryParms, null, null).Result;

                return val;
            }
            catch
            {

            }

            return "";
        }
    }
}

namespace Pi_Hole.Models
{
    public class TypeModel
    {
        public string type { get; set; }
    }    

    public class VersionModel
    {
        public string version { get; set; }
    }

    public class OverTimeData10MinsModel
    {
        public Dictionary<string, int> domains_over_time { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> ads_over_time { get; set; } = new Dictionary<string, int>();
    }

    public class TopItemsModel
    {
        public Dictionary<string, int> top_queries { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> top_ads { get; set; } = new Dictionary<string, int>();
    }

    public class GetQuerySourcesModel
    {
        public Dictionary<string, int> top_sources { get; set; } = new Dictionary<string, int>();
    }

    public class GetForwardDestinationsModel
    {
        public Dictionary<string, object> forward_destinations { get; set; } = new Dictionary<string, object>();
    }

    public class GetQueryTypesModel
    {
        public Dictionary<string, decimal> querytypes { get; set; } = new Dictionary<string, decimal>();
    }

    public class GetAllQueriesModel
    {
        public DataModel Data { get; set; } = new DataModel();
        public class DataModel
        {
            public string[,] data { get; set; }
        }

        public List<DataSerializedModel> DataSerialized { get; set; } = new List<DataSerializedModel>();
        public class DataSerializedModel
        {
            public string TimeString { get; set; }
            public string Type { get; set; }
            public string Domain { get; set; }
            public string Client { get; set; }
            public StatusEnum Status { get; set; } //1 = blocked by gravity.list, 2 = forwarded to upstream server, 3 = answered by local cache, 4 = blocked by wildcard blocking

            public enum StatusEnum
            {
                BlockedByGravity,
                ForwardedToUpstreamServer,
                AnsweredByCache,
                BlockedByWildCard
            }
        }

        public List<DataSerializedModel> UpdateSerializedModel()
        {
            var ret = new List<DataSerializedModel>();

            if (Data.data != null)
            {
                for (int i = 0; i < Data.data.GetLength(0); i++)
                {
                    var s = new DataSerializedModel();

                    s.TimeString = Data.data[i, 0];
                    s.Type = Data.data[i, 1];
                    s.Domain = Data.data[i, 2];
                    s.Client = Data.data[i, 3];

                    switch (Data.data[i, 4])
                    {
                        case "1":
                            s.Status = DataSerializedModel.StatusEnum.BlockedByGravity;
                            break;
                        case "2":
                            s.Status = DataSerializedModel.StatusEnum.ForwardedToUpstreamServer;
                            break;
                        case "3":
                            s.Status = DataSerializedModel.StatusEnum.AnsweredByCache;
                            break;
                        case "4":
                            s.Status = DataSerializedModel.StatusEnum.BlockedByWildCard;
                            break;
                    }

                    ret.Add(s);
                }
            }

            DataSerialized = ret;

            return ret;
        }
    }

    public class EnableModel
    {
        public string status { get; set; }
    }

    public class DisableModel
    {
        public string status { get; set; }
    }

    public class SummaryRaw
    {
        public int domains_being_blocked { get; set; }
        public int dns_queries_today { get; set; }
        public int ads_blocked_today { get; set; }
        public decimal ads_percentage_today { get; set; }
        public int unique_domains { get; set; }
        public int queries_forwarded { get; set; }
        public int queries_cached { get; set; }
        public int clients_ever_seen { get; set; }
        public int unique_clients { get; set; }
        public int dns_queries_all_types { get; set; }
        public int reply_NODATA { get; set; }
        public int reply_CNAME { get; set; }
        public int reply_IP { get; set; }
        public int privacy_level { get; set; }
        public string status { get; set; }
        public GravityLastUpdatedModel gravity_last_updated { get; set; } = new GravityLastUpdatedModel();

        public class GravityLastUpdatedModel
        {
            public bool file_exists { get; set; }
            public long absolute { get; set; }
            public RelativeModel relative { get; set; } = new RelativeModel();

            public class RelativeModel
            {
                public int days { get; set; }
                public int hours { get; set; }
                public int minutes { get; set; }
            }
        }
    }
}