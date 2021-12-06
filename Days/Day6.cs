public class Day6{
List<ulong> fishList = new List<ulong>();
long[] fishCountArray = new long[9];
long fishSum;
int spawnCounter;
    public void Calc(){
        string path = "Days/inputDay6.txt";
        using (StreamReader sr = File.OpenText(path)){
            string? tempString;
            while ((tempString = sr.ReadLine()) != null){
                fishList = tempString.Split(',').Select(UInt64.Parse).ToList();
            }
        }
        for (int i = 0; i < fishList.Count; i++){
            fishCountArray[fishList[i]]++;
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
    public long fishCountBetter(int day){
        for (int i = 0; i < day; i++){
            long tempCount = fishCountArray[0];
            for (int j = 0; j < fishCountArray.Length -1; j++){
               fishCountArray[j] = fishCountArray[j+1];
            }
            fishCountArray[6]+= tempCount;
            fishCountArray[8] = tempCount;    
        }
        for (int i = 0; i < fishCountArray.Length; i++){
            fishSum += fishCountArray[i];
        }
        Console.WriteLine(fishSum);
        return fishSum;
    }
}