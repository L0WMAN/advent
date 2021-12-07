using System.Linq;
public class Day7{
    int[] hPositions;
    int currentMinGas;
    int atPosition;
    int gasSum;
    int maxDistance;
    bool breakFlag = false;
    public void Calc(){
        string path = "Days/inputDay7.txt";
        using (StreamReader sr = File.OpenText(path)){
            string? tempString;
            while ((tempString = sr.ReadLine()) != null){
                hPositions = tempString.Split(',').Select(Int32.Parse).ToArray<int>();
            }
        }
        //for (int i = 0; i < hPositions.Length; i++){
        //    Console.WriteLine(hPositions[i]);
        //}
        maxDistance = hPositions.Max();
        Console.WriteLine($"max: {maxDistance}");
        currentMinGas = sumOfSteps(maxDistance) * hPositions.Length;
        //start at center
        for (int i=0; i <= maxDistance; i++){
            while (!breakFlag){
                for (int j=0; j < hPositions.Length; j++){
                    int spacesMoved = Math.Abs(hPositions[j] - i);
                    gasSum+= sumOfSteps(spacesMoved);
                    if (gasSum > currentMinGas){
                        breakFlag = true;
                        break;
                    }
                }
                if (gasSum > currentMinGas){
                    gasSum = 0;
                    break;
                }
                currentMinGas = gasSum;
                atPosition = i;
                gasSum = 0;
                break;
            }
            gasSum = 0;
            breakFlag = false;
        }
        Console.WriteLine($"Min gas required: {currentMinGas} at position {atPosition}");
    }
    public int sumOfSteps(int x){
        int sum = 0;
        sum+=x*(x+1)/2;
        return sum;
    }
}