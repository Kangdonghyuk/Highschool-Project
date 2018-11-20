// ManagerData is our custom class that holds our defined objects we want to store in XML format 
 public class ManagerData 
 { 
    // We have to define a default instance of the structure 
   public Data manage;
    // Default constructor doesn't really do anything at the moment 
   public ManagerData() { }

   // 관리할것들
   public struct Data 
   {
       public int[] nPlayerArray;
       public bool m_TutoState;
   }
}
