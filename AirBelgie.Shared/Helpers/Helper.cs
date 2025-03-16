using AirBelgie.Service;

namespace AirBelgie.Shared.Helpers;

public static class Helpers
{
    public static async Task<string> GenerateUsername(IKeyValService kv)
    {
        int nextNum = await kv.GetKeyValAsync<int>("nextUsernameNum");
        
        if (nextNum == 0)
        {
            nextNum = 1;
        }
        else
        {
            nextNum++;
        }
        
        await kv.CreateOrUpdateKeyValAsync("nextUsernameNum", nextNum);
        
        return $"BGE{nextNum}";
    }
}