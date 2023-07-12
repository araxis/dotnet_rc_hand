using RcHand.Hw.Core;
using RcHand.Hw.Core.Messages;

namespace RcHand.Hw.Bluetooth.Parsers
{
    public class MoveFingerMessageParser : IMessageParser
    {
        public IMessage Parse(string[] data)
        {
            if (data is null) return WrongFormatMessage.Instance;
            if (data.Length < 3) return WrongFormatMessage.Instance;
            if (!int.TryParse(data[2], out var position)) return WrongFormatMessage.Instance;
            return data[1] switch
            {
                Fingers.Thumb => new MoveThumb(position),
                Fingers.Index => new MoveIndex(position),
                Fingers.Middle => new MoveMiddle(position),
                Fingers.Ring => new MoveRing(position),
                Fingers.Little => new MoveLittle(position),
                _ => WrongFormatMessage.Instance
            };
        }
    }
}