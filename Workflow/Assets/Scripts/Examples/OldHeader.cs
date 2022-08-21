// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class Welcome
    {
        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public WelcomeData[] Data { get; set; }
    }

    public partial class WelcomeData
    {
        [JsonProperty("steps")]
        public Dictionary<string, Step> Steps { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("initialStep")]
        public string InitialStep { get; set; }

        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("estimatedDuration")]
        public Duration EstimatedDuration { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("users")]
        public string[] Users { get; set; }
    }

    public partial class Duration {

        [JsonProperty("data")]
        public DurationData Data { get; set; }
    }

    public partial class DurationData
    {

        [JsonProperty("hours")]
        public long hours { get; set; }

        [JsonProperty("minutes")]
        public long minutes { get; set; }
    }

    public partial class Step
    {
        [JsonProperty("data")]
        public StepData Data { get; set; }
    }

    public partial class StepData
    {
        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("template")]
        public Template Template { get; set; }

        [JsonProperty("editNameMode")]
        public bool EditNameMode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("next", NullValueHandling = NullValueHandling.Ignore)]
        public string Next { get; set; }

        [JsonProperty("layouts")]
        public Layout[] Layouts { get; set; }

        [JsonProperty("show")]
        public bool Show { get; set; }
    }

    public partial class Layout
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("templateOptions")]
        public TemplateOptions TemplateOptions { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class TemplateOptions
    {
        [JsonProperty("position")]
        public PositionEnum Position { get; set; }

        [JsonProperty("options")]
        public Option[] Options { get; set; }

        [JsonProperty("qrfield")]
        public string Qrfield { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("hPosition")]
        public Position HPosition { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }

        [JsonProperty("vPosition")]
        public Position VPosition { get; set; }

        [JsonProperty("required")]
        public bool TemplateOptionsRequired { get; set; }

        [JsonProperty("max")]
        public long? Max { get; set; }

        [JsonProperty("precision")]
        public long? Precision { get; set; }

        [JsonProperty("videoUrl")]
        public string VideoUrl { get; set; }

        [JsonProperty("imgUrl")]
        public string ImgUrl { get; set; }

        [JsonProperty("disabled")]
        public bool Disabled { get; set; }

        [JsonProperty("unit")]
        public Unit Unit { get; set; }

        [JsonProperty("min")]
        public long? Min { get; set; }
    }

    public partial class Option
    {
        [JsonProperty("value")]
        public Value Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public partial class Template
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("weights")]
        public long[] Weights { get; set; }

        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public enum Position { Center };

    public enum PositionEnum { Centered };

    public enum Unit { C, Empty };

    public partial struct Value
    {
        public bool? Bool;
        public long? Integer;

        public static implicit operator Value(bool Bool) => new Value { Bool = Bool };
        public static implicit operator Value(long Integer) => new Value { Integer = Integer };
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    /*internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                NameConverter.Singleton,
                OrientationConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }*/

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PositionConverter.Singleton,
                ValueConverter.Singleton,
                PositionEnumConverter.Singleton,
                UnitConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PositionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Position) || t == typeof(Position?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "center")
            {
                return Position.Center;
            }
            throw new Exception("Cannot unmarshal type Position");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Position)untypedValue;
            if (value == Position.Center)
            {
                serializer.Serialize(writer, "center");
                return;
            }
            throw new Exception("Cannot marshal type Position");
        }

        public static readonly PositionConverter Singleton = new PositionConverter();
    }

    internal class ValueConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Value) || t == typeof(Value?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return new Value { Integer = integerValue };
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return new Value { Bool = boolValue };
            }
            throw new Exception("Cannot unmarshal type Value");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Value)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value);
                return;
            }
            if (value.Bool != null)
            {
                serializer.Serialize(writer, value.Bool.Value);
                return;
            }
            throw new Exception("Cannot marshal type Value");
        }

        public static readonly ValueConverter Singleton = new ValueConverter();
    }

    internal class PositionEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(PositionEnum) || t == typeof(PositionEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "centered")
            {
                return PositionEnum.Centered;
            }
            throw new Exception("Cannot unmarshal type PositionEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (PositionEnum)untypedValue;
            if (value == PositionEnum.Centered)
            {
                serializer.Serialize(writer, "centered");
                return;
            }
            throw new Exception("Cannot marshal type PositionEnum");
        }

        public static readonly PositionEnumConverter Singleton = new PositionEnumConverter();
    }

    internal class UnitConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Unit) || t == typeof(Unit?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Unit.Empty;
                case "�C":
                    return Unit.C;
            }
            throw new Exception("Cannot unmarshal type Unit");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Unit)untypedValue;
            switch (value)
            {
                case Unit.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Unit.C:
                    serializer.Serialize(writer, "�C");
                    return;
            }
            throw new Exception("Cannot marshal type Unit");
        }

        public static readonly UnitConverter Singleton = new UnitConverter();
    }
}

public class OldHeader : MonoBehaviour
{
    string UnityUrl = "https://demo0173267.mockable.io";
    InputField outputArea;

    public void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        if (outputArea == null)
            Debug.Log("It is null");
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    public void GetData() => StartCoroutine(GetData_Coroutine());

    public IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = UnityUrl;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
            {
                string temp = request.downloadHandler.text;

                outputArea.text = request.downloadHandler.text;
            }
        }
    }
}

//using namespace QuickType;
public class RootClass
{    
    public List<QuickType.Welcome> welcome_ { get; set; }
    public List<QuickType.WelcomeData> welcomeData_ { get; set; }
    public List<QuickType.Step> step_ { get; set; }
    public List<QuickType.StepData> stepData_ { get; set; }
    public List<QuickType.Layout> layout_ { get; set; }
    public List<QuickType.Item> item_ { get; set; }
    public List<QuickType.TemplateOptions> templateOptions_ { get; set; }
    public List<QuickType.Option> option_ { get; set; }
    public List<QuickType.Template> template_ { get; set; }
    //public List<List<QuickType.PositionConverter>> pos_ { get; set; }

}