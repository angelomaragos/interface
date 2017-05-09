// Angelo Maragos
//  This assignment demonstrates implementing a generic interface, ISet<T> and implementing a Set class.  The Set class implements the ISet<T> interface.
//  The additional classes are created, inherting from Set class, that are used to add, remove, verify/contains, combine etc string, int, and char elements.  
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace UML.Assignment7
{

    //define methods for for generic interface ISet<T>
   public interface ISet<T>
    {
       
      void Add(T element);
      T Remove(T element);
      bool Contains(T element);
      ISet<T> Intersect(ISet<T> otherset);
      ISet<T> Union(ISet<T> otherset);
      T[] ToArray();
      

    }

    //Set class implements defined ISet<T> interface
    class Set<T> : ISet<T>
      
    {
      

      
        public ArrayList array1 = new ArrayList();  // array list...can store various data types

      
        
       public void Add(T element)
        {
            if (array1.Contains(element))
            {
                return;                                 //if element exists in array, exit...otherwise add element to array
            }
            else
                array1.Add(element);
           
         
            
        }


      public T Remove(T element)
       {
           dynamic d = element;
           if (array1.Contains(element))
           {
               array1.Remove(element);                //if element exists in array, remove it and return element, otherwise do nothing
               return element;

           }

               
           else
               return d;

         

       }
     public  bool Contains(T element)
       {

           if (array1.Contains(element))                //if element exists in set (array list) return true, otherwise return false
           {
               return true;
           }
           else
               return false;

         
       }

     public ISet<T> Intersect(ISet<T> otherset)
     {
         Set<T> IntersectS = new Set<T>();

         var aa = array1;
         var aaa = aa.ToArray();
        

         var a = otherset;
         var b = a.ToArray();
      //   dynamic addT = 0;
      //   int aaaLen = aaa.Length;
      //   int bLen = b.Length;
       

        
         foreach (T item in array1)                    //if item exists in array1 and otherset...add item to IntersectS
             if ( b.Contains(item))
                 // if(b.Equals(array1))
               //  if (otherset.Contains(item))
         
                 IntersectS.Add(item);
             

         return IntersectS;

     }
     public ISet<T> Union (ISet<T> otherset)
     {
         ArrayList array0 = new ArrayList();
         Set<T> UnionS = new Set<T>();

         array0 = array1;
         var a = otherset;
         var b = a.ToArray();   //other set to array
          array0.AddRange(b);                         //combine both sets
          foreach (T item in array0)
              UnionS.Add(item);
       
         return UnionS;
        
     }
     



       public T[] ToArray()
           
       {
         //  Console.WriteLine("........");
           int len = array1.Count;  //size of array1
           int i = 0;
           T[] arr = new T[len];  //new T element array

           while (i < len)
           {
               arr[i] = (T)array1[i];  //save element/times from array list to T array
            //   Console.WriteLine(arr[i]);
               i++;
           }

        return arr;
       }


       public int count = 0;

    }

    class Num<T> : Set<T>  //declare num/int class for test harness
    {
        
    }

    class CharT<T> : Set<T>  // //declare char class for test harness
    {

    }

    class Wrd<T> : Set<T>   //declare word/string class for test harness
    {

    }
    
    class Program
    {
        static void Main(string[] args)
        {
           // create numObj's  and add elements to set...does not add "repeat" values
            var numObj = new Num<int>();
            numObj.Add(1);
            numObj.Add(2);
            numObj.Add(3);
            numObj.Add(3);
            numObj.Add(4);
            numObj.Add(5);
            numObj.Add(95);
            numObj.Add(100);



            var numObj2 = new Num<int>();
            numObj2.Add(4);
            numObj2.Add(4);
            numObj2.Add(5);
            numObj2.Add(6);
            numObj2.Add(7);
            numObj2.Add(8);
            numObj2.Add(9);
            numObj2.Add(96);
            numObj2.Add(100);


            var toArr = numObj.ToArray();  //elements in set copied into an array
            int numObjLen = toArr.Length;  // length of array

            var toArr2 = numObj2.ToArray();  
            int numObjLen2 = toArr2.Length;




           
            int numObjCnt = 0;
            int numObj2Cnt = 0;

        
         

             while (numObjCnt < numObjLen)   //while less than the size of the array
            {
                Console.WriteLine("Numbers added to numObj: {0} ", toArr[numObjCnt]);  //print elements of array
                numObjCnt ++;

            }

             bool chck = numObj.Contains(5);  //check to see if value is set
             Console.WriteLine("True or false.  Does numObj set contain the value 5? {0}",chck);
             Console.WriteLine();
             Console.WriteLine("Removing 95.");
            dynamic r = numObj.Remove(95);  //remove item from set  //////////////////////////////////
             chck = numObj.Contains(95);
             Console.WriteLine("True or false.  Does numObj set contain the value 95? {0}", chck);

             Console.WriteLine();

             while (numObj2Cnt < numObjLen2)  //while less than the size of the second object array
             {
                 Console.WriteLine("Numbers added to num2Obj: {0} ", toArr2[numObj2Cnt]);
                 numObj2Cnt++;

             }

             chck = numObj2.Contains(56);
             Console.WriteLine("True or false.  Does numObj set contain the value 56? {0}", chck);

             Console.WriteLine();

           //  Console.WriteLine("Removing 400.");
           //  numObj2.Remove(400);

            


             dynamic i = numObj.Intersect(numObj2);  // determine what value is in both sets
             dynamic ii = i.ToArray();  //copy to array
             int iLen = ii.Length;  // determine size of array
             int iLenCnt = 0;

             Console.WriteLine("Intersect of numObj set & numObj2 set ");
             while (iLenCnt < iLen)
             {
                 Console.WriteLine(ii[iLenCnt]);  //print the value(s) that exists in both sets
                 iLenCnt++;
             }


             Console.WriteLine();
             Console.WriteLine();

            

              dynamic u = numObj.Union(numObj2);  // conbimne both sets
              dynamic uu = u.ToArray();  //copy contents to array
              int uLen = uu.Length;  // size of array
              int uLenCnt = 0;

              Console.WriteLine("Combining numObj set & numObj2 set ");
              while (uLenCnt < uLen)
              {
                  Console.WriteLine(uu[uLenCnt]);  //print conbines values
                  uLenCnt++;
              }


           

              Console.WriteLine("*****************************************");

              var wrdObj = new Wrd<string>();

              wrdObj.Add("green");
              wrdObj.Add("blue");
              wrdObj.Add("blue");
              wrdObj.Add("purple");
              wrdObj.Add("violet");

              var wrdObj2 = new Wrd<string>();

              wrdObj2.Add("red");
              wrdObj2.Add("white");
              wrdObj2.Add("black");
              wrdObj2.Add("red");
              wrdObj2.Add("purple");





            var wrd_toArr = wrdObj.ToArray();
            int wrd_numObjLen = wrd_toArr.Length;

            var wrd_toArr2 = wrdObj2.ToArray();
            int wrd_numObjLen2 = wrd_toArr2.Length;





            int wrd_numObjCnt = 0;
            int wrd_numObj2Cnt = 0;




            while (wrd_numObjCnt < wrd_numObjLen)
            {
                Console.WriteLine("Words added to wrdObj: {0} ", wrd_toArr[wrd_numObjCnt]);
                wrd_numObjCnt++;

            }

             chck = wrdObj.Contains("green");
            Console.WriteLine("True or false.  Does wrdObj set contain the word green? {0}", chck);
            Console.WriteLine();
            Console.WriteLine("Removing violet.");
            wrdObj.Remove("violet");
            chck = wrdObj.Contains("violet");
            Console.WriteLine("True or false.  Does wrdObj set contain the value violet? {0}", chck);

            Console.WriteLine();
            Console.WriteLine();

            while (wrd_numObj2Cnt < wrd_numObjLen2)
             {
                 Console.WriteLine("Words added to wrdObj2: {0} ", wrd_toArr2[wrd_numObj2Cnt]);
                 wrd_numObj2Cnt++;

             }

             chck = wrdObj2.Contains("Orange");
             Console.WriteLine("True or false.  Does wrdObj2 set contain the value Orange? {0}", chck);

             Console.WriteLine();


             dynamic wi = wrdObj.Intersect(wrdObj2);  ///////////
             dynamic wii = wi.ToArray();
             int wiLen = wii.Length;
             int wiLenCnt = 0;

             Console.WriteLine("Intersect of wrdObj set & wrdObj2 set ");
             while (wiLenCnt < wiLen)
             {
                 Console.WriteLine(wii[wiLenCnt]);
                 wiLenCnt++;
             }

            // Console.WriteLine("wiLenCnt {0}", wiLenCnt);



             Console.WriteLine();
             Console.WriteLine();


             dynamic wu = wrdObj.Union(wrdObj2);  ///////////
             dynamic wuu = wu.ToArray();
             int wuLen = wuu.Length;
             int wuLenCnt = 0;

             Console.WriteLine("Combining wrdObj set & wrdObj2 set ");
             while (wuLenCnt < wuLen)
             {
                 Console.WriteLine(wuu[wuLenCnt]);
                 wuLenCnt++;
             }


             Console.WriteLine("*****************************************");

             var chrObj = new CharT<char>();

              chrObj.Add('a');
              chrObj.Add('e');
              chrObj.Add('i');
              chrObj.Add('o');
              chrObj.Add('u');
              chrObj.Add('y');


              var chrObj2 = new CharT<char>();

              chrObj2.Add('a');
              chrObj2.Add('b');
              chrObj2.Add('c');
              chrObj2.Add('d');
              chrObj2.Add('e');
              chrObj2.Add('y');


              var chr_toArr = chrObj.ToArray();
              int chr_numObjLen = chr_toArr.Length;

              var chr_toArr2 = chrObj2.ToArray();
              int chr_numObjLen2 = chr_toArr2.Length;





              int chr_numObjCnt = 0;
              int chr_numObj2Cnt = 0;




              while (chr_numObjCnt < chr_numObjLen)
              {
                  Console.WriteLine("Char added to chrObj: {0} ", chr_toArr[chr_numObjCnt]);
                  chr_numObjCnt++;

              }

            //  Console.WriteLine("chr_numObjCnt is {0}", chr_numObjCnt);
            //  Console.WriteLine("chr_numObjLen is {0}", chr_numObjLen);




              chck = chrObj.Contains('a');
              Console.WriteLine("True or false.  Does chrObj set contain the char ' a '? {0}", chck);
              Console.WriteLine();
              Console.WriteLine("Removing ' y '.");
              chrObj.Remove('y');
              chck = chrObj.Contains('y');
              Console.WriteLine("True or false.  Does chrObj set contain the char ' y '? {0}", chck);

              Console.WriteLine();
              Console.WriteLine();


              while (chr_numObj2Cnt < chr_numObjLen2)
              {
                  Console.WriteLine("Char added to chrObj2: {0} ", chr_toArr2[chr_numObj2Cnt]);
                  chr_numObj2Cnt++;

              }


              chck = chrObj2.Contains('a');
              Console.WriteLine("True or false.  Does chrObj2 set contain the char ' a '? {0}", chck);
              Console.WriteLine();
              Console.WriteLine("Removing ' y '.");
            //  chrObj2.Remove('y');
              chck = chrObj2.Contains('y');
              Console.WriteLine("True or false.  Does chrObj2 set contain the char ' y '? {0}", chck);

              Console.WriteLine();
              Console.WriteLine();


              dynamic ci = chrObj.Intersect(chrObj2);  ///////////
              dynamic cii = ci.ToArray();
              int ciLen = cii.Length;
              int ciLenCnt = 0;

              Console.WriteLine("Intersect of chrObj set & chrObj2 set ");
              while (ciLenCnt < ciLen)
              {
                  Console.WriteLine(cii[ciLenCnt]);
                  ciLenCnt++;
              }



              dynamic cu = chrObj.Union(chrObj2);  ///////////
              dynamic cuu = cu.ToArray();
              int cuLen = cuu.Length;
              int cuLenCnt = 0;

              Console.WriteLine("Combining chrObj set & chrObj2 set ");
              while (cuLenCnt < cuLen)
              {
                  Console.WriteLine(cuu[cuLenCnt]);
                  cuLenCnt++;
              }




              Console.WriteLine();
              Console.WriteLine();

              Console.WriteLine("Press enter to exit.");


            Console.ReadLine();

        }
    }
}



