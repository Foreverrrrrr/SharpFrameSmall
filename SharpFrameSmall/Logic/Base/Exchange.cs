using static SharpFrameSmall.Logic.Base.ProcessBase;

namespace SharpFrameSmall.Logic.Base
{
    public class Exchange
    {
        public static bool External_IO(Send_Variable io)
        {
            switch (io)
            {
                case Send_Variable.Start:
                    if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.ResetOver))
                    {
                        if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Suspend))//恢复
                        {
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Suspend, false);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Start, true);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.AwaitStarted, true);
                            return true;
                        }
                        else if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Reset))//复位后启动
                        {

                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Reset, false);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Start, true);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.AwaitStarted, true);
                            return true;
                        }
                        else if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.AwaitStarted)
                            && !ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Start))//连续启动
                        {
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Start, true);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.AwaitStarted, true);
                            return true;
                        }
                    }
                    break;
                case Send_Variable.Suspend:
                    if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.ResetOver))
                    {
                        if (ProcessBase.GetEnumValue(ProcessBase.Send_Variable.AwaitStarted) &&
                            ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Start))//暂停
                        {
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Suspend, true);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Start, false);
                            return true;
                        }
                    }
                    break;
                case Send_Variable.Stop:
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.ResetOver, false);
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.Suspend, false);
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.Stop, true);
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.Reset, false);
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.Start, false);
                    ProcessBase.SetEnum(ProcessBase.Send_Variable.AwaitStarted, false);
                    return true;
                case Send_Variable.Reset:
                    if (!ProcessBase.GetEnumValue(ProcessBase.Send_Variable.ResetOver))
                    {
                        if ((ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Stop)
                            || ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Suspend))
                            && !ProcessBase.GetEnumValue(ProcessBase.Send_Variable.Reset))
                        {
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.ResetOver, false);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Suspend, false);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Stop, false);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.Reset, true);
                            ProcessBase.SetEnum(ProcessBase.Send_Variable.AwaitStarted, false);
                            ProcessBase.Thread_Dispose();
                            return true;
                        }
                    }
                    break;
                case Send_Variable.E_Stop:
                    break;
                default:
                    break;
            }
            return false;
        }
    }
}
