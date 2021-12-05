
public class Day3 {
    int[] gammaRate = new int[12];
    double gammaDecimal;
    int[] epsilonRate = new int[12];
    double epsilonDecimal;
    int consumption;
    string? tempString;
    int[] zeroesArray = new int[12];
    int[] onesArray = new int[12];
    List<String> tempZeroes = new List<String>();
    List<String> tempOnes = new List<String>();
    string? oxygenGeneratorRating;
    double ogrDecimal;
    double scrubberDecimal;
    string? scrubberRating;
    int onesCount = 0;
    int zeroesCount = 0;
    List<String> workingList = new List<String>();
    int[] ogr = new int[12];
    int[] co2 = new int[12];
    public void Calc(){
        string path = "Days/inputDay3.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                tempString.ToCharArray();
                //Console.WriteLine(tempString[0]);
                for (int i = 0; i < 12; i++){
                    if (tempString[i] == '1'){
                        onesArray[i]++;
                    }
                    else if (tempString[i] == '0'){
                        zeroesArray[i]++;
                    }                
            }
        }
        for (int i = 0; i < 12; i++){
            if (onesArray[i] > zeroesArray[i]){
                gammaRate[i] = 1;
                epsilonRate[i] = 0;
            }
            else{
                gammaRate[i] = 0;
                epsilonRate[i] = 1;
            }
            Console.WriteLine(i + " : " + zeroesArray[i] + " | " + onesArray[i]);
        }
        Console.Write("\nGammaBinary: ");
        for (int i = 0; i < 12; i++){
            Console.Write(gammaRate[i]);
        }
        Console.Write("\nEpsilonBinary: ");
        for (int i = 0; i < 12; i++){
            Console.Write(epsilonRate[i]);
        }
        Console.Write("\n");
        for(int i = 0; i < 12; i++){
            gammaDecimal+= Math.Pow(2, 11-i)*gammaRate[i];
            epsilonDecimal+= Math.Pow(2, 11-i)*epsilonRate[i];
        }
            
        //gammaDecimal = Math.Pow(2,4)*gammaRate[0] + Math.Pow(2,3)*gammaRate[1] + Math.Pow(2,2)*gammaRate[2] + Math.Pow(2,1)*gammaRate[3] + Math.Pow(2,0)*gammaRate[4];
        //epsilonDecimal = Math.Pow(2,4)*epsilonRate[0] + Math.Pow(2,3)*epsilonRate[1] + Math.Pow(2,2)*epsilonRate[2] + Math.Pow(2,1)*epsilonRate[3] + Math.Pow(2,0)*epsilonRate[4];
        Console.WriteLine("GR: " + gammaDecimal + " ER: " + epsilonDecimal);
        Console.WriteLine("Consumption: " + gammaDecimal*epsilonDecimal);
        }
    }
    public double calcOGR(){
        string path = "Days/inputDay3.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                workingList.Add(tempString);
                //Console.WriteLine(tempString[0]);           
            }
        }
        for (int i = 0; i < 12; i++){
            for (int j = 0; j < workingList.Count; j++){
                tempString = workingList[j];
                if (tempString[i] == '1'){
                    tempOnes.Add(tempString);
                }
                else if (tempString[i] == '0'){
                    tempZeroes.Add(tempString);
                }
            }
            if (tempOnes.Count == tempZeroes.Count){
                workingList = new List<String>(tempOnes);
                Console.WriteLine("ones: " + workingList.Count);
            }
            else if (tempOnes.Count > tempZeroes.Count){
                workingList = new List<String>(tempOnes);
                Console.WriteLine("ones: " + workingList.Count);
            }
            else if (tempOnes.Count < tempZeroes.Count){
                workingList = new List<String>(tempZeroes);
                Console.WriteLine("zeroes: " + workingList.Count);
            }
            //Console.WriteLine(workingList.ElementAt(index:0));
            tempOnes.Clear();
            tempZeroes.Clear();
            if (workingList.Count == 1){break;}
        }
        oxygenGeneratorRating = workingList[0];
        Console.WriteLine("ogr: " + oxygenGeneratorRating);

        for(int i = 0; i < 12; i++){
            if (oxygenGeneratorRating[i] == '1'){
                ogr[i] = 1;
            }
            else {
                ogr[i] = 0;
            }
            ogrDecimal+= Math.Pow(2, 11-i)*ogr[i];
        }
        Console.WriteLine("OGR Decimal: " + ogrDecimal);
        return ogrDecimal;
    }
    public double calcCO2(){
        string path = "Days/inputDay3.txt";
        using (StreamReader sr = File.OpenText(path)){
            while ((tempString = sr.ReadLine()) != null){
                //Console.WriteLine(tempString);
                workingList.Add(tempString);
                //Console.WriteLine(tempString[0]);
            }
        }
        for (int i = 0; i < 12; i++){
            for (int j = 0; j < workingList.Count; j++){
                tempString = workingList[j];
                if (tempString[i] == '1'){
                    tempOnes.Add(tempString);
                }
                else if (tempString[i] == '0'){
                    tempZeroes.Add(tempString);
                }
            }
            if (tempOnes.Count == tempZeroes.Count){
                workingList = new List<String>(tempZeroes);
                Console.WriteLine("zeroes: " + workingList.Count);
            }
            else if (tempOnes.Count < tempZeroes.Count){
                workingList = new List<String>(tempOnes);
                Console.WriteLine("ones: " + workingList.Count);
            }
            else if (tempOnes.Count > tempZeroes.Count){
                workingList = new List<String>(tempZeroes);
                Console.WriteLine("zeroes: " + workingList.Count);
            }
            tempOnes.Clear();
            tempZeroes.Clear();
            if (workingList.Count == 1){break;}
        }
        scrubberRating = workingList[0];
        //Console.WriteLine("scrub: " + scrubberRating);
        Int64.Parse(scrubberRating.ToCharArray());
        Console.WriteLine("sr:" + scrubberRating);
        for(int i = 0; i < 12; i++){
            if (scrubberRating[i] == '1'){
                co2[i] = 1;
            }
            else {
                co2[i] = 0;
            }
            scrubberDecimal+= Math.Pow(2, 11-i)*co2[i];
        }
        Console.WriteLine("CO2Scrub: " + scrubberDecimal);
        return scrubberDecimal;
    }
}