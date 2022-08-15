using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MyList<T> // <T>정체: C#에서 구현된 List는 Generic타입이므로 <T>를 사용해 어떤 타입에도 사용가능하게 만듬
    {
        const int DEFAULT_SIZE = 1;
        T[] _data = new T[DEFAULT_SIZE];

        public int Count = 0; // 실제로 사용중인 데이터개수
        public int Capacity { get { return _data.Length; } } // 예약된 데이터개수 -> 자동으로 정해지는 배열의 길이

        // O(1) 예외케이스: 공간늘리는 부분 즉, 이사비용이 드는 부분은 많이 실행이 안된다는 가정하에 무시할수있다.
        public void Add(T item)
        {
            // 1. 공간이 충분히 남아있는지 확인
            if (Count >= Capacity)
            {
                // 공간을 늘려서 확보한다
                T[] newArr = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                {
                    newArr[i] = _data[i];
                }
                _data = newArr;
            }

            // 2. 공간에 데이터를 넣어준다
            _data[Count] = item;
            Count++;
        }

        // 인덱서구현
        public T this[int index]
        {
            get { return _data[index]; }
            set { _data[index] = value; }
        }

        // O(N)
        public void RemoveAt(int index)
        {
            //           101 102 103 104 105
            // 앞으로 당김 101 102 104 105 105
            for (int i = index; i < Count - 1; i++) // 최악의 경우를 가정하여 시간복잡도를 계산한다.
            {
                _data[i] = _data[i + 1];
            }
            // 제일 끝부분을 정수형이라면 0, 클래스면 null로 초기화 -> 101 102 104 105 0
            _data[Count - 1] = default(T);
            // 배열크기 감소 -> 101 102 104 105
            Count--;
        }
    }

    class Board
    {
        // 맵 구성에 필요한 정보를 저장할 적절한 자료구조 선택 -> 내가 만들 맵은 크기가 고정이기 때문에 배열을 쓰는것이 좋다
        public int[] _data = new int[25]; // 배열
        public MyList<int> _data2 = new MyList<int>(); // 동적배열 -> C++에서 동적배열은 vector로 만들었으나 C#에선 List로 만든다. 장점: 크기조절이 유동적이다
        public LinkedList<int> _data3 = new LinkedList<int> (); // 연결리스트 -> 장점: 중간 삽입/삭제가 빠르다

        // 초기화
        public void Initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);
        }
    }
}
