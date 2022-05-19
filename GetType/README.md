# 메타데이터

리플렉션과 애트리뷰트

Reflection
- 런타임에 객체의 형식(Type) 정보를 들여다보는 기능
- System.Object은 형식 정보를 반환하는 GetType() 메소드 보유
- 즉, 모든 데이터 형식은 System.Object 형식을 상속하므로 GetType() 메소드 또한 보유

Object
- 모든 데이터 형식의 조상
- 다음의 메소드를 물려받아 가지고 있음
    - Equals()
    - GetHashCode()
    - GetType()
    - ReferenceEquals()
    - ToString()

- Object.GetType()과 System.Type
    - Object.GetType() 메소드는 System.Type 형식 결과를 반환
    - Type 형식은 .NET 데이터 형식의 모든 정보(메소드, 필드, 프로퍼티 등)를 표현
```
int a = 0;
Type type = a.GetType();
FieldInfo[] fields = type.GetFields(); // 필드 목록 조회

foreach (FieldInfo field in fields)
    Console.WriteLine("Type:{0}, Name:{1}", field.FieldType.Name, field.Name);
```