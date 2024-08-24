namespace LeftOverLove.Common;
public static class GeolocationUtils
{
    private const double EarthRadiusKm = 6371.0;

    public static double HaversineDistance(double latatude1, double longatude1, double latatude2, double longatude2)
    {
        double lat1Rad = DegreeToRadian(latatude1);
        double lon1Rad = DegreeToRadian(longatude1);
        double lat2Rad = DegreeToRadian(latatude2);
        double lon2Rad = DegreeToRadian(longatude2);

        double dLat = lat2Rad - lat1Rad;
        double dLon = lon2Rad - lon1Rad;

        double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) * Math.Pow(Math.Sin(dLon / 2), 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        return EarthRadiusKm * c * 1000;
        double DegreeToRadian(double degree) => degree * (Math.PI / 180.0);
    }
}
