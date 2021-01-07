using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.BusinessLayer.Converters
{
    /// <summary>
    ///     Convert int directionId into string direction name
    /// </summary>
    public class DirectionConverter : JsonConverter<int>
    {
        /// <summary>
        ///     This method need for reading json and convert to c# object
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override int Read(ref Utf8JsonReader reader,
                                 Type typeToConvert,
                                 JsonSerializerOptions options)
        {
            var directionName = reader.GetString();

            using var context = new DIMSCoreContext();
            var direction = context.Directions.FirstOrDefault(x => x.Name == directionName);

            return direction?.DirectionId ?? 0;
        }

        /// <summary>
        ///     This method need for reading c# object and convert to json
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer,
                                   int value,
                                   JsonSerializerOptions options)
        {
            var directionId = value;

            using var context = new DIMSCoreContext();
            var direction = context.Directions.FirstOrDefault(x => x.DirectionId == directionId);

            if (direction != null)
            {
                writer.WriteStringValue(direction.Name);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}