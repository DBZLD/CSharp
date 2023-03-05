# 윳마블

## 기간 
### 기간은 2월 19일부터 3월 5일까지 만들었습니다.


## 게임 소개

### 윳마블은 윳놀이와 부루마블을 합친 게임입니다.
### 윳놀이의 맵과 말 이동 및 윳 시스템을 가지고 있고 부루마블의 건물 및 승리, 패배 시스테을 가지고 있습니다.

![캡처_2023_03_05_15_24_20_660](https://user-images.githubusercontent.com/111506781/222945262-b04b888d-09f1-4164-9049-c3ba9521ff75.png)

### 게임이 시작하면 나오는 자세한 설명


## 맵 

![캡처_2023_03_05_15_24_29_413](https://user-images.githubusercontent.com/111506781/222945269-85fe7c4a-d5b5-40da-bbbe-e91c2782bc25.png)

### 맵은 윳놀이의 맵과 동일하며 곳곳에 감옥과 이벤트 칸이 있다.


## 기술 스택




제일 많이 쓴 것은 for문과 if문이다.반복해야하는 것과 변수가 많아서 for문으로 반복하고 if문으로 변수를 찾아내어 대부분을 만들었다.


![캡처_2023_03_05_16_23_56_998](https://user-images.githubusercontent.com/111506781/222947783-fc29eba6-bb5c-47d6-9e7f-bb0c198d265b.png)

메인 루프를 위한 while과 루프를 끊기위한 break를 썼다

![캡처_2023_03_05_16_23_28_28](https://user-images.githubusercontent.com/111506781/222947624-58c41725-eb79-44de-a017-d01ef3ab90c8.png)

보유, 미보유 확인, 거절과 같은 형식이 많았기에 bool형식을 썼고 기타 수치를 알아야 하는것은 int형식을 썼고 좌표를 쉽게 설정하기위해 point구조체를 만들었다.

![캡처_2023_03_05_16_30_03_522](https://user-images.githubusercontent.com/111506781/222947956-33f94411-cc99-4d8a-905c-8bbbee712d2d.png)


루프를 제외한 거의 모든 과정을 클래스에 넣어 메소드로 만들었고 지금은 보안을 신경쓰지 않아도 될거 같아서 클래스 안에 모든 메소드와 변수들를 public으로 만들었다.

![캡처_2023_03_05_16_35_26_784](https://user-images.githubusercontent.com/111506781/222948021-10fb1ea4-f778-4761-92af-217cd5f9474b.png)




![캡처_2023_03_05_16_24_42_295](https://user-images.githubusercontent.com/111506781/222947859-58454d0b-f62f-4c68-b34e-244ad16dd41a.png)

시작할때 setwindowsize와 cursorvisible, title을 사용해 윈도우창을 설정했고 디자인을 위해 setcursorposition과 foregroundcolor, write를 썼다. write($"")로 변수를 출력했다.


![캡처_2023_03_05_16_36_06_783](https://user-images.githubusercontent.com/111506781/222948032-ee84fa31-ee9a-4dd2-b85f-18a85400c20e.png)

화면을 넘기거나 선택할때 키입력을 받기 위해 readkey와 colsolekeyinfo를 썼다.

## 신경쓴 점 / 느낀 점

단순 반복 작업이 많았지만 코드를 최대한 줄이기 위해서 계속 생각하였다. 하지만 코드를 너무 많이 바꾸다 보니 시간이 오래 걸렸고
관련된 모든 변수들의 인과관계를 생각해야하는것이 복잡하였다.
