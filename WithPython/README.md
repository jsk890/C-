# C#에서 파이썬 코드 사용하기

- DLR은 CLR 위에서 동작하며, 파이썬이나 루비와 같은 동적 언어를 실행
- DLR은 C#같은 정적 언어 코드에서 파이썬같은 동적언어코드와의 상호동작 지원
- DLR과 CLR 사이의 상호동작은 dynamic 형식을 통해 이루어짐

#### !파이썬 패키지 연동 필요
1. Visual Studio -> 도구 탭
2. Nuget 패키지 관리자 -> 패키지 관리자 콘솔
3. install-Package IronPython 입력
```
namespace WithPython
{

    class MainApp
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "홍길동");
            scope.SetVariable("p", "010-1234-5646");
            ScriptSource source = engine.CreateScriptSourceFromString(
//******************파이썬*******************
//파이썬이므로 코드 앞쪽 Tab 주의
                @"
class NameCard :
    name = ''
    phone = ''

    def __init__(self, name, phone) :
        self.name = name
        self.phone = phone

    def printNameCard(self) :
        print self.name + ', ' + self.phone

NameCard(n, p)
");
//******************파이썬*******************
            dynamic result = source.Execute(scope);
            result.printNameCard();

            Console.WriteLine("{0}, {1}", result.name, result.phone);
        }
    }
}
```
![gitcs7](https://user-images.githubusercontent.com/55019081/169218577-87bc34c7-79f7-4703-9696-9d34dbbb4c66.GIF)
