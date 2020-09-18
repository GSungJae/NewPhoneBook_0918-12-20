using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePhoneBook
{
    public class PhoneBookManager
    {
        const int MAX_CNT = 100;
        PhoneInfo[] infoStorage = new PhoneInfo[MAX_CNT];

        int curCnt = 0;
        public void ShowMenu()
        {
            Console.WriteLine("------------------------ 주소록 --------------------------");
            Console.WriteLine("1. 입력  |  2. 목록  |  3. 검색  |  4. 삭제  |  5. 종료");
            Console.WriteLine("---------------------------------------------------------");
            Console.Write("선택: ");
            Console.WriteLine("");
        }

        public void InputData()
        {
            Console.Write("이름을 입력해주세요(필수). :");
            string name = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(name)) // if (name == "");   if(name.Length <1)    if(name.Equals(""))
            {
                Console.WriteLine("이름을 입력해주세요.");
                return;
            }
            else
            {
                int dataIdx = SearchName(name);
                if(dataIdx>-1)
                {
                    Console.WriteLine("이미 등록된 이름입니다. 다른 이름으로 입력해주세요.");
                    return;
                }
            }
            Console.Write("전화번호를 입력해주세요(필수). :");
            string phone = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(phone)) // if (name == "");   if(name.Length <1)    if(name.Equals(""))
            {
                Console.WriteLine("전화번호를 입력해주세요.");
                return;
            }
            Console.Write("생일을 입력해주세요(선택). :");
            string birth = Console.ReadLine().Trim();

            if (birth.Length < 1)
                infoStorage[curCnt++] = new PhoneInfo(name, phone);
            else
                infoStorage[curCnt++] = new PhoneInfo(name, phone, birth);

        }

        public void ListData()
        {
            if (curCnt == 0)
            {
                Console.WriteLine("입력된 데이터가 없습니다.");
                return;
            }
            for (int i = 0; i < curCnt; i++)
            {
                infoStorage[i].ShowPhoneInfo();
                // PhoneInfo curInfo = infoStorage[i];
                // curInfo.ShowPhoneInfo();
            }
        }

        public void SearchData()
        {
            //Console.WriteLine("주소록 검색을 시작합니다.");
            //Console.Write("이름을 입력해주세요.: ");
            //string name = Console.ReadLine().Trim().ToLower().Replace(" ","");
            //int findCnt = 0; // bool true false 로 해도됨.
            //for (int i = 0; i < curCnt; i++)
            //{
            //    // == , Equals(), CompareTo() 문자열 비교할때 주로 사용함
            //    if(infoStorage[i].Name.CompareTo(name)==0)// 비교할땐 둘 다 조건을 같게한다.
            //    {
            //        infoStorage[i].ShowPhoneInfo();
            //        findCnt++;
            //    }
            //}
            //if(findCnt<1)
            //    Console.WriteLine("검색된 데이터가 없습니다.");
            //else
            //    Console.WriteLine($"총 {findCnt} 명이 검색되었습니다.");

            Console.WriteLine("주소록 검색을 시작합니다.");
            int dataIdx = SearchName();
            if (dataIdx < 0)
                Console.WriteLine("검색된 데이터가 없습니다.");
            else
                infoStorage[dataIdx].ShowPhoneInfo();
        }

        private int SearchName()
        {
            Console.Write("이름을 입력해주세요.: ");
            string name = Console.ReadLine().Trim().ToLower().Replace(" ", "");

            for (int i = 0; i < curCnt; i++)
            {
                // == , Equals(), CompareTo() 문자열 비교할때 주로 사용함
                if (infoStorage[i].Name.CompareTo(name) == 0)// 비교할땐 둘 다 조건을 같게한다.
                {
                    return i;
                }
            }
            return -1;
        }

        private int SearchName(string name)
        {
            
            name = name.Trim().ToLower().Replace(" ", "");

            for (int i = 0; i < curCnt; i++)
            {
                // == , Equals(), CompareTo() 문자열 비교할때 주로 사용함
                if (infoStorage[i].Name.CompareTo(name) == 0)// 비교할땐 둘 다 조건을 같게한다.
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeleteData()
        {
            Console.WriteLine("주소록 삭제를 시작합니다.");

            int dataIdx = SearchName();
            if (dataIdx < 0)
                Console.WriteLine("삭제할 데이터가 없습니다.");
            else
            {
                for (int i=dataIdx; i<curCnt; i++)
                {
                    infoStorage[i] = infoStorage[i + 1];
                }
                curCnt--;
                Console.WriteLine("삭제가 완료되었습니다.");
            }
        }
    }
}

