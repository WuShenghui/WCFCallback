Application:
http://www.dotnetcurry.com/showarticle.aspx?ID=721

Store Procedure:
http://stackoverflow.com/questions/20028989/display-progress-of-execution-through-progress-bar

/****** Object:  StoredProcedure [dbo].[sp_LongProcess]    Script Date: 10/05/2014 12:41:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[sp_LongProcess] 
As Begin

BEGIN TRAN

    Declare @i Int;
    Declare @msg VarChar(50);
    Set @i = 0;
    while (@i < 100) Begin
        WaitFor Delay '00:00:02';

        Set @i = @i + 10;
        Set @msg = Convert(VarChar(10), @i) + ' PERCENT COMPLETE';
        RaisError(@msg, 1, 1) With NoWait
    End
    
COMMIT TRAN
   
End

--exec sp_LongProcess
GO


WCF：如何将net.tcp协议寄宿到IIS:
http://www.cnblogs.com/Gyoung/archive/2012/12/11/2812555.html


Questions：
1、无法连接到 net.tcp://wsh-pc/Service.svc。连接尝试持续了 00:00:06.6313421 时间跨度。TCP 错误代码 10061: 由于目标计算机积极拒绝，无法连接。 192.168.1.105:808。
Solution：启动Net.Tcp Listener Adapter服务