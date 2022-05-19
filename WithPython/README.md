# C#에서 파이썬 코드 사용하기

- DLR은 CLR 위에서 동작하며, 파이썬이나 루비와 같은 동적 언어를 실행
- DLR은 C#같은 정적 언어 코드에서 파이썬같은 동적언어코드와의 상호동작 지원
- DLR과 CLR 사이의 상호동작은 dynamic 형식을 통해 이루어짐

#### !파이썬 패키지 연동 필요
1. Visual Studio -> 도구 탭
2. Nuget 패키지 관리자 -> 패키지 관리자 콘솔
3. install-Package IronPython 입력