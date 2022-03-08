using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//런타임에 형식 정보 얻기
// attribute 개념 & 활용법

// reflection : 런타임에 객체의 형식 정보를 들여다보는 기능
// System.Object은 형식 정보를 GetType method 보유
// Type 형식은 .net 데이터 형식의 모든 정보 (method, feild, property)를 표현

namespace CSstudy
{
    internal class Reflection
    {

    }

    partial class REFELCTION
    {
        void Main1(string[] args)
        {
            int a = 0;
            Type type = a.GetType();
            FieldInfo[] feilds = type.GetFields();

            foreach (FieldInfo field in feilds)
                Console.WriteLine($"Type:{field.FieldType.Name}, Name:{field.Name}");

            // System.Reflection.BindingFlags 열거형 상수를 조합
            // 옵션은 GetFields에만 적용이 되는것이 아니라 모든 메소드에 사용이 가능하다.
            var fields1 = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
            var fields2 = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var fields3 = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);


        }
    }

    //reflection을 이용한 객체 생성 및 활용

    // System.Activator class에게 System.Type 객체를 입력하여 인스턴스 생성
    // Property class의 GetValue()로 값을 읽고 SetValue()로 값을 기록
    // MethodInfo class의 Invoke() 메소드를 통해 메소드 호출

    class Profile
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public void Print()
        {
            Console.WriteLine($"{Name}, {Phone}");
        }
    }

    partial class REFELCTION
    {
        void Main2(string[] args)
        {
            // Profile 생성자를 사용하지 않은 이유
            // 형식을 매개변수로 받는 경우, 다른 구조체/class의 instance를 만들 수 있다.
            // Runtime에 형식을 읽어들어서 생성 가능
            Type type = typeof(Profile);
            Profile profile = (Profile)Activator.CreateInstance(type);

            PropertyInfo name = type.GetProperty("Name");
            PropertyInfo phone = type.GetProperty("Phone");

            name.SetValue(profile, "wmk", null);
            name.SetValue(profile, "990-3331", null);

            Console.WriteLine($"{name.GetValue(profile, null)}, {phone.GetValue(profile, null)}");

            MethodInfo method = type.GetMethod("Print");
            method.Invoke(profile, null);
        }
    }

    // reflection을 이용한 형식 생성(내보내기)
}
