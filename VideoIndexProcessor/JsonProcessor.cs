using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace VideoIndexProcessor
{
    public class JsonProcessor
    {
        public async Task ExtractInstances(Stream input, Stream output)
        {
            using var reader = new JsonTextReader(new StreamReader(input));
            var inputJson = await JObject.LoadAsync(reader);
            var results = new List<JObject>();
            var root = inputJson["videos"][0]["insights"];
            
            ExtractInstances(root, "transcript", "text", results);
            ExtractInstances(root, "keywords", "text", results);
            ExtractInstances(root, "topics", "name", results);
            ExtractInstances(root, "faces", "name", results);
            ExtractInstances(root, "labels", "name", results);
            ExtractInstances(root, "scenes", "id", results);
            ExtractInstances(root, "audioEffects", "name", results);
            ExtractInstances(root, "sentiments", "sentimentType", results);
            ExtractInstances(root, "emotions", "type", results);

            results.Sort(CompareStartTimestamp);

            var outputJson = new JArray(results);
            using var writer = new JsonTextWriter(new StreamWriter(output));
            await outputJson.WriteToAsync(writer);
        }

        private static int CompareStartTimestamp(JObject left, JObject right)
        {
            var leftTimestamp = TimeSpan.Parse(left.Value<string>("start"));
            var rightTimestamp = TimeSpan.Parse(right.Value<string>("start"));
            return leftTimestamp.CompareTo(rightTimestamp);
        }

        private void ExtractInstances(JToken root, string insight, string valuePropertyName, List<JObject> results)
        {
            Console.WriteLine($"Extracting insights: {insight}");
            var container = (JArray)root[insight];
            foreach (var element in container.Children<JObject>())
            {
                var insightValue = element[valuePropertyName].Value<string>();
                foreach (var instance in element["instances"].Children<JObject>())
                {
                    var newInstance = (JObject)instance.DeepClone();
                    newInstance["insightType"] = insight;
                    newInstance["insightValue"] = insightValue;

                    results.Add(newInstance);
                }
            }
        }
    }
}