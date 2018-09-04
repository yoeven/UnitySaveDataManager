# Unity Save Data Manager



## Usage

  - Drop "SaveDataManager" Prefab into scene.
  - Save any data type.
  - Getting key that doesn't exist will raise an error.
 
 ### Saving
  ```D
 //Save int
SaveDataManager.SaveData("Highscore", 100);

//Save string
SaveDataManager.SaveData("Player Username", "John");

//Save Array
SaveDataManager.SaveData("Levels", new  int[] { 1, 2, 3, 4, 5 });
 ```
 
 ### Getting Data
  ```D
int Highscore = SaveDataManager.GetData<int>("Highscore");

int[] Levels = SaveDataManager.GetData<int[]>("Levels");
 ```
 
 ### Checking if Key Exist
  ```D
if (SaveDataManager.Contains("Highscore")){
		int  Highscore = SaveDataManager.GetData<int>("Highscore");
}
 ```



## Todos

 - Add encryption system, currently using binary saving.



License
----

MIT
