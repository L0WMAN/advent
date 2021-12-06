public class Day6{
List<ulong> fishList = new List<ulong>();
int spawnCounter;
    public void Calc(){
        string path = "Days/test6.txt";
        using (StreamReader sr = File.OpenText(path)){
            string? tempString;
            while ((tempString = sr.ReadLine()) != null){
                fishList = tempString.Split(',').Select(UInt64.Parse).ToList();
                fishList.Sort();
                fishList.Reverse();
            }
        }
    }
    //return number of fish on given day
    public long fishCount(int day){
        for (int i = 0; i < day; i++){
            for (int j =0; j < fishList.Count; j++){
                if (fishList[j] > 0){
                    fishList[j]--;           
                }
                else if (fishList[j] == 0){
                    fishList[j] = 6;
                    spawnCounter++;
                }
            }
            for (int k = 0; k < spawnCounter; k++){
                fishList.Add(8);
            }
            spawnCounter = 0;
        }
        Console.WriteLine(fishList.Count);
        return fishList.Count;
    }

    //this sure isnt better
    public long fishCountBetter(int day){
        for (int i = 0; i < day; i++){
            for (int j =0; j < fishList.Count; j++){
                if (fishList[j] > 0){
                    fishList[j]--;           
                }
                else if (fishList[j] == 0){
                    //fishList[j] = 6;
                    spawnCounter+=fishList.Count - j;
                    for (int k = j; k < fishList.Count; k++){
                        fishList[k] = 6;
                    }
                    break;
                }
            }
            for (int k = 0; k < spawnCounter; k++){
                fishList.Insert(0, 8);
            }
            spawnCounter = 0;
            fishList.Sort();
            fishList.Reverse();
        }
        Console.WriteLine(fishList.Count);
        return fishList.Count;
    }
}
