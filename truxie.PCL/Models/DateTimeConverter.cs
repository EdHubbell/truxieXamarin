using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace truxie.PCL
{
	public class DateTimeConverter: JsonConverter
	{
		protected  DateTime Create (Type objectType, JObject jObject)
		{
			return DateTime.MinValue;
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
		{
			serializer.Serialize (writer, value);
		}

		public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
				return null;
			DateTime target =DateTime.MinValue;
			try {
				if (reader.Value is DateTime)
		 
					target = (DateTime)reader.Value;
				else if (reader.Value.ToString () [reader.Value.ToString ().Length-1] == 'Z')
					target = DateTime.Parse (reader.Value.ToString ());
				else
					target = DateTime.ParseExact (reader.Value.ToString (), "ddd MMM dd HH:mm:ss +ffff yyyy", new System.Globalization.CultureInfo ("en-US"));

			} catch (Exception ex) {
				var message = ex.Message;
			}
			return target;
		}

		public override bool CanConvert (Type objectType)
		{
			return true;
		}
	}


}

