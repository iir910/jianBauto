
// 声明,调用.
//找字
SetRowsNumber(0)
//注意：每次制作完字库后，需要自行把制作的字库文件添加到脚本“附件”中
TracePrint SetDictEx(0, "Attachment:mq_soft.txt")
TracePrint UseDict(0)
//以上两句脚本只需要调用一次
dim a,b
a = 560
b = 600
//TracePrint "消息框的坐标 "&""&a&","&b
Dim intX,intY
Dim cjx,cjy
Dim t
Dim 找图
Import "GK.lua" '果壳插件
Dim 次数=0 '记录刷小怪的次数
Delay 1000
//===================================================================
//========判断目前所在状态======
//在战斗中?找"暂停".
FindPic 1193,14,1265,85,"Attachment:暂停.png","202020",0,0.6,intx,inty
If intx > -1 And inty > -1 Then
    TracePrint "在战斗中"
    Goto 战斗中	
End If
TracePrint "不在战斗中"
Delay 200
Rem 刷图中
Delay 1000
FindPic 867,638,1024,699,"Attachment:切换队伍.png","202020",0,0.7,intx,inty
If intx > -1 And inty > -1 Then
    TracePrint "在刷图中,等待2秒,寻找杂鱼.... "
    Delay  2000
    Goto H4
End If
TracePrint "不在刷图中"
//==========================================================================================
//在章节图?
//判断是否在第3章; 范围内找数字3
FindStr(3,84,101,125,"3","7BDFF7-151515|63CFF7-151515|39AAEF-151515|31AEDE-151515|29C7F7-151515",0.9,intX,intY)
If intX > -1 And intY > -1 Then
    TracePrint intX
    TracePrint intY
    Delay 50
    ShowMessage "在第3章\n点击3-4", 1000,a,b
    Delay 50
    //点击3-4 的坐标
    ShowMessage "选择3-4", 1000, a,b
    Tap 610, 360
    Delay 1000
    Tap 900, 500
    ShowMessage "立刻前往", 1000, a, b
    Goto 舰队选择
End If
//结束脚本
EndScript
Rem 舰队选择
TracePrint "舰队选择"
Delay 1500
Dim X1,Y1
FindColor 357,558,384,581,"188AF7",0,0.8,X1,Y1
If X1 > -1 And Y1 > -1 Then
    ShowMessage "第一舰队已经选择", 1000, a, b
    TracePrint "第一舰队已经选择"
    //判断有没有两支队伍
    //找2队
    Delay 1500
    Dim x2,y2
    FindColor 507,553,528,580,"188AF7",0,0.8,x2,y2
    If x2 > -1 And y2 > -1 Then 
        TracePrint "第2舰队 ok"
        ShowMessage "第2舰队 ok", 1000, a,b
        TracePrint x2
        TracePrint y2
        //取消选择
        Tap x2, y2
        TracePrint "取消2"
    Else 
        TracePrint "第2舰队 no"
        ShowMessage "第2舰队 no", 1000, a, b
        Delay 1500
        Dim x3,y3
        FindColor 649,557,669,577,"188AF7",0,0.8,x3,y3
        If x3 > -1 And y3 > -1 Then 
            TracePrint "第3舰队 ok"
            ShowMessage "第3舰队 ok", 1000, a,b
            TracePrint x3
            TracePrint y3
            //取消选择
            Tap x3, y3
            TracePrint "取消3"
        Else 
            TracePrint "第3舰队 no"
            ShowMessage "第3舰队 no", 1000, a, b
            Delay 1500
            Dim x4,y4
            FindColor 791,555,813,579,"188AF7",0,0.8,x4,y4
            If x4 > -1 And y4 > -1 Then 
                TracePrint "第4舰队 ok"
                ShowMessage "第4舰队 ok", 1000, a,b
                TracePrint x4
                TracePrint y4
                //取消选择
                Tap x4, y4
                TracePrint "取消4"
            Else 
                TracePrint "第4舰队 no"
                ShowMessage "第4舰队 no", 1000, a,b 
            End If   //4
        End If //3  
    End If //2
End If //1
	
//立即前往
Delay 1000
Tap 960, 560
TracePrint "立即前往 "
Goto 章节3_4
//舰队选择
EndScript
Rem 章节3_4
t=5  //定义等待时间
for t 
    t=t-1
    showmessage "等待" & cstr(t) & "秒"
    delay 1000
Next
TracePrint "调整画面."
//showmessage "拖动画面到中间"
Swipe 700, 170, 700, 100, 300 //用300毫秒,拖动画面,上移70像素..调整画面.
Delay 1000
Rem H4   //搜,小怪   4H
If 次数 >= 3 Then 
    TracePrint "野生的BOSS出现了,快扔大师球."
    Delay 100
    Goto Boss
End If
FindColor 164,537,1125,571,"42CFEF",3,0.9,intX,intY //第4行
If intX > -1 And intY > -1 Then
    次数 = 次数 + 1
    TracePrint "这是第"& 次数 &"次"
    TracePrint "发现杂鱼",intX,intY
    Delay 200
    Goto 移动中
    TracePrint intX,intY,"第4行里,没发现杂鱼...."
    Else goto H3	
End If
Rem H3  //搜,小怪   3H
If 次数 >= 3 Then 
    TracePrint "野生的BOSS出现了,快扔大师球."
    Delay 100
    Goto Boss
End If
FindColor 236,434,1136,460,"42CFEF",3,0.9,intX,intY //第3行
If intX > -1 And intY > -1 Then
    次数 = 次数 + 1
    TracePrint "这是第"& 次数 &"次"
    TracePrint "发现杂鱼",intX,intY
    Delay 200
    Goto 移动中
    TracePrint intX,intY,"第3行里,没发现杂鱼...."
    Else goto H2	
End If
Rem H2  //搜,小怪   2h
If 次数 >= 3 Then 
    TracePrint "野生的BOSS出现了,快扔大师球."
    Delay 100
    Goto Boss
End If
FindColor 311,334,682,360,"42CFEF",3,0.9,intX,intY //第2行
If intX > -1 And intY > -1 Then
    次数 = 次数 + 1
    TracePrint "这是第"& 次数 &"次"
    TracePrint "发现杂鱼",intX,intY
    Delay 200
    Goto 移动中
    TracePrint intX,intY,"第2行里,没发现杂鱼...."
    Else goto H1	
End If
Rem H1  //搜,小怪    
If 次数 >= 3 Then 
    TracePrint "野生的BOSS出现了,快扔大师球."
    Delay 100
    Goto Boss
End If
FindColor 360,239,807,271,"42CFEF",3,0.9,intX,intY //第 1
If intX > -1 And intY > -1 Then
    次数 = 次数 + 1
    TracePrint "这是第"& 次数 &"次"
    TracePrint "发现杂鱼",intX,intY
    Delay 200
    Goto 移动中
    TracePrint intX,intY,"第1行里,没发现杂鱼...."
    Delay 2000
    Else goto H4	
End If
Rem boss  //检查boss颜色.
FindColor 1120,371,1207,546,"524DFF",1,1,intX,intY
If intX > -1 And intY > -1 Then
    TracePrint intX
    TracePrint intY
    TracePrint "找到boss位置!!!果断推倒!!"
    goto 移动中
End If
Rem 移动中
Tap intx,inty
t=3
for t
    t=t-1
    showmessage "移动倒计时" & cstr(t) & "秒"
    delay 2000
next
//判断在"出击"否
Rem 出击
FindStr(1047,600,1157,659,"出击","DEF7FF-151515|84D7FF-202020|B5EFFF-202020|42CFEF-202020|63BADE-202020",0.7,cjX,cjY)
If cjX > -1 And cjY > -1 Then
    TracePrint "在出击界面",cjx
    delay 100
    //检查自律on
    FindStr(161,77,190,101,"on","4AF7AD-151515",0.8,intX,intY)
    If intX > -1 And intY > -1 Then
        TracePrint "自律-打开"
    Else //调成自律模式
        TracePrint "自律-关闭",intX,intY
        delay 100
        Tap 180,100
        Delay 300
        TracePrint "自律-打开"
        Delay 400
        Tap 600,80 //关闭提示界面
    End If
    TracePrint "点击出击",cjx,cjy
    Tap 1060, 600
    t=40
    Goto 战斗中
    Else TracePrint "不在出击?"
    Goto 遇到伏击
End If
EndScript
Rem 遇到伏击
Delay 2000
FindPic 210,424,466,502,"Attachment:伏击.png","050505",0,0.9,intX,intY
If intX > -1 And intY > -1 Then
    TracePrint intX
    TracePrint "遇到伏击"
    Tap 900,400 //规避
    Delay 3000
    Goto 出击
Else 
    Delay 100
    Goto H4
End If
Rem 战斗中
/*
for t
t=t-1
showmessage "战斗中,等待" & cstr(t) & "秒"
delay 1000
next
FindStr(231,464,275,507,"","4AE36B-353535|00A608-353535",0.9,intX,intY)
If intX > -1 And intY > -1 Then
	TracePrint intX
	TracePrint intY
	Else TracePrint "继续等待"
	t=10
End If
*/
Import "Thread.lua"
//找胜利,并点击
A=array(229,459,279,510,"Attachment:win.png")
dim arr=GK.FullTM2(A,190)
if arr(0)   then
    ShowMessage "胜利!!!"
    TracePrint "战斗结束.win"
    Delay 100
    TracePrint arr(0),arr(1),arr(2)
End If
//=========停止脚本===============
//EndScript
/*
//当条件成立时，进入循环，直到条件不成立，退出循环
Do While arr(0) = -1
    TracePrint "正在战斗中，等待....."
    ShowMessage "正在战斗中，等待....."
    A=array(229,459,279,510,"Attachment:win.png")
    arr=GK.FullTM2(A,3)
Delay 1000
    TracePrint arr(0),arr(1),arr(2)
Loop
TracePrint "循环结束"
*/
Delay 2000
TracePrint "获得道具,点击"
Tap 300,300  //获得道具先点击一下,
Delay 2000
找图=array("Attachment:jn.png","202020",0,0.6,false)
If Gk.Full(找图) Then 
    TracePrint Gk.Full(找图)
    Delay 1000
    TracePrint "获得卡片,点一下"
    Tap 300,100 //获得卡片,点一下
Else 
    TracePrint "没有获得卡片"
End If
Delay 1000
ShowMessage "经验结算"
Delay 2200
Tap 1100,600 //获得经验,确认完毕.
/*
t=4
for t
t=t-1
showmessage "倒计时" & cstr(t) & "秒后,返回刷图"
delay 1000
Next
*/
Delay 2500
Goto 刷图中
