namespace AdventOfCode2023;

public class Day05 : IDay
{
    private const string file = @"inputs\day05.txt";
    private static readonly List<string> input = Helper.GetInputLines(file);

    private List<long> seeds = [];
    private readonly SortedDictionary<long, (long, long)> seedToSoilMap = [];
    private readonly SortedDictionary<long, (long, long)> soilToFertilizerMap = [];
    private readonly SortedDictionary<long, (long, long)> fertilizerToWaterMap = [];
    private readonly SortedDictionary<long, (long, long)> waterToLightMap = [];
    private readonly SortedDictionary<long, (long, long)> lightToTemperatureMap = [];
    private readonly SortedDictionary<long, (long, long)> temperatureToHumidityMap = [];
    private readonly SortedDictionary<long, (long, long)> humidityToLocationMap = [];
    private readonly List<SortedDictionary<long, (long, long)>> maps = [];

    public long Run1()
    {
        maps.AddRange([
            seedToSoilMap,
            soilToFertilizerMap,
            fertilizerToWaterMap,
            waterToLightMap,
            lightToTemperatureMap,
            temperatureToHumidityMap,
            humidityToLocationMap]);

        FillMaps();

        List<long> results = [];
        foreach (long seed in seeds)
        {
            long result = seed;
            foreach (SortedDictionary<long, (long Destination, long RangeLength)> map in maps)
            {
                long temp = -1;
                foreach (long source in map.Keys)
                {
                    if (source > result)
                    {
                        break;
                    }

                    temp = source;
                }

                if (temp < 0)
                {
                    continue;
                }

                long diff = result - temp;
                if (diff < map[temp].RangeLength)
                {
                    long dest = map[temp].Destination;
                    result = dest + diff;
                }
            }

            results.Add(result);
        }

        return results.Min();
    }

    private void FillMaps()
    {
        bool
            isSeedToSoilMap = false,
            isSoilToFertilizerMap = false,
            isFertilizerToWaterMap = false,
            isWaterToLightMap = false,
            isLightToTemperatureMap = false,
            isTemperatureToHumidityMap = false,
            isHumidityToLocationMap = false;


        foreach (var line in input)
        {
            if (line.StartsWith("seeds:"))
            {
                seeds = line.Split(':').TakeLast(1).First().Trim().Split().Select(long.Parse).ToList();
            }
            else if (string.IsNullOrEmpty(line))
            {
                isSeedToSoilMap = false;
                isSoilToFertilizerMap = false;
                isFertilizerToWaterMap = false;
                isWaterToLightMap = false;
                isLightToTemperatureMap = false;
                isTemperatureToHumidityMap = false;
                isHumidityToLocationMap = false;
            }
            else if (line.StartsWith("seed-to-soil map:"))
            {
                isSeedToSoilMap = true;
            }
            else if (line.StartsWith("soil-to-fertilizer map:"))
            {
                isSoilToFertilizerMap = true;
            }
            else if (line.StartsWith("fertilizer-to-water map:"))
            {
                isFertilizerToWaterMap = true;
            }
            else if (line.StartsWith("water-to-light map:"))
            {
                isWaterToLightMap = true;
            }
            else if (line.StartsWith("light-to-temperature map:"))
            {
                isLightToTemperatureMap = true;
            }
            else if (line.StartsWith("temperature-to-humidity map:"))
            {
                isTemperatureToHumidityMap = true;
            }
            else if (line.StartsWith("humidity-to-location map:"))
            {
                isHumidityToLocationMap = true;
            }
            else if (isSeedToSoilMap)
            {
                AddToMap(line, seedToSoilMap);
            }
            else if (isSoilToFertilizerMap)
            {
                AddToMap(line, soilToFertilizerMap);
            }
            else if (isFertilizerToWaterMap)
            {
                AddToMap(line, fertilizerToWaterMap);
            }
            else if (isWaterToLightMap)
            {
                AddToMap(line, waterToLightMap);
            }
            else if (isLightToTemperatureMap)
            {
                AddToMap(line, lightToTemperatureMap);
            }
            else if (isTemperatureToHumidityMap)
            {
                AddToMap(line, temperatureToHumidityMap);
            }
            else if (isHumidityToLocationMap)
            {
                AddToMap(line, humidityToLocationMap);
            }
        }
    }

    private static void AddToMap(string line, SortedDictionary<long, (long Destination, long Rangelength)> map)
    {
        string[] tokens = line.Split();
        long destination = long.Parse(tokens[0]);
        long source = long.Parse(tokens[1]);
        int length = int.Parse(tokens[2]);

        map.Add(source, (Destination: destination, Rangelength: length));
    }

    public long Run2()
    {

        return 2;
    }
}
