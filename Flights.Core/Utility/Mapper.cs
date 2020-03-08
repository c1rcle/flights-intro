namespace Flights.Core.Utility
{
    public static class Mapper
    {
        public static TDestination MapProperties<TSource, TDestination>(TSource source, TDestination destination)
        {
            foreach (var srcProperty in source.GetType().GetProperties())
            {
                foreach (var dstProperty in destination.GetType().GetProperties())
                {
                    if (srcProperty.Name == dstProperty.Name &&
                        srcProperty.PropertyType == dstProperty.PropertyType)
                    {
                        dstProperty.SetValue(destination, srcProperty.GetValue(source));
                    }
                }
            }
            return destination;
        }
    }
}