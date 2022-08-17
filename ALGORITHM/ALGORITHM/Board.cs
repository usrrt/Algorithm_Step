using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class MyLinkedListNode<T>
    {
        // 참조값이용(주소값을 사용한다)
        public T Data; // 방안에 들어갈 T는 어떠한 객체라도 들어갈수있게 Data로 만듦
        public MyLinkedListNode<T> Next; // 다음 방을 가리키는 주소
        public MyLinkedListNode<T> Prev; // 이전의 방을 가리키는 주소
    }

    // 앞,뒤 접근시 시간복잡도가 상수로 아주 빠르지만 중간임의접근시 시간복잡도는 N(처음부터 하나씩 타고가야하므로)
    class MyLinkedList<T>
    {
        // 처음과 마지막방은 알고있어야한다.
        public MyLinkedListNode<T> Head = null; // 처음
        public MyLinkedListNode<T> Tail = null; // 마지막

        public int Count = 0;

        // O(1)
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            // 만약 방이 아직 없었다면, 새로 추가한 첫번째방이 곧 Head다.
            if(Head == null)
            {
                Head = newRoom;
            }

            // 기존에 존재하던 [마지막 방]과 [새롭게 추가되는 방]을 연결해준다.
            if(Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;
            }

            // [새로추가된방]을 [마지막 방]으로 인정한다.
            Tail = newRoom;
            Count++;

            return newRoom;
        }
    
        // 방을 날린다 -> 101 102    104 105
        // O(1)
        public void Remove(MyLinkedListNode<T> room)
        {
            // [기존의 첫번째방]을 날릴시
            if (Head == room)
            {
                // [첫번째 다음방]을 Head로 인정한다
                Head = Head.Next;
            }

            // [기존의 마지막방] 삭제시
            if(Tail == room)
            {
                // [마지막 방 이전방]을 Tail로 인정한다.
                Tail = Tail.Prev;
            }

            // 중간부위 삭제시
            // [삭제할 방 이전의 방]이 존재한다면
            if(room.Prev != null)
            {
                // [삭제할 이전방의 다음방]과 [삭제할 방 다음방]을 연결
                room.Prev.Next = room.Next;
            }

            if(room.Next != null)
            {
                room.Next.Prev = room.Prev;
            }

            Count--;
        }

    }

    class Board
    {
        public int[] _data = new int[25]; // 배열
        public MyLinkedList<int> _data3 = new MyLinkedList<int> ();

        public void Initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
            MyLinkedListNode<int> temp  = _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(temp);
        }
    }
}
