using System;
using System.Linq;
using DIMS_Core.DataAccessLayer.Models;
using Newtonsoft.Json;

namespace DIMS_Core.BusinessLayer.Converters
{
    /// <summary>
    ///     Convert int directionId into string direction name
    /// </summary>
    public class DirectionConverter : JsonConverter
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return Type.GetTypeCode(typeToConvert) == TypeCode.Int32;
        }

        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            var directionName = reader.Value.ToString();

            using var dimsCoreContext = new DIMSCoreContext();
            var direction = dimsCoreContext.Directions.FirstOrDefault(x => x.Name == directionName);

            return direction?.DirectionId ?? 0;
        }

        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            var directionId = (int)value;

            using var dimsCoreContext = new DIMSCoreContext();
            var direction = dimsCoreContext.Directions.FirstOrDefault(x => x.DirectionId == directionId);

            if (direction != null)
            {
                writer.WriteValue(direction.Name);
            }
            else
            {
                writer.WriteNull();
            }
        }
    }
}