namespace TickOffList.Converters; 

public class MeetingColorConverter : IMeetingColorConverter {
    private static Dictionary<string, Brush> _brushDictionary;

    public MeetingColorConverter() {
        _brushDictionary =
            new Dictionary<string, Brush>();
        _brushDictionary.Add("changge.png", Brush.OrangeRed);
        _brushDictionary.Add("chenxi.png", Brush.Green);
        _brushDictionary.Add("chishucai.png", Brush.GreenYellow);
        _brushDictionary.Add("chishuiguo.png", Brush.DarkGreen);
        _brushDictionary.Add("chizaocan.png", Brush.Yellow);
        _brushDictionary.Add("chouyan.png", Brush.Brown);
        _brushDictionary.Add("dadianhua.png", Brush.Red);
        _brushDictionary.Add("hejiu.png", Brush.Brown);
        _brushDictionary.Add("heshui.png", Brush.Gold);
        _brushDictionary.Add("huahua.png", Brush.Purple);
        _brushDictionary.Add("jianfei.png", Brush.Pink);
        _brushDictionary.Add("jianshen.png", Brush.Blue);
        _brushDictionary.Add("jiejiu.png", Brush.Red);
        _brushDictionary.Add("jieyan.png", Brush.Red);
        _brushDictionary.Add("kanshu.png", Brush.Blue);
        _brushDictionary.Add("kaoyan.png", Brush.Orange);
        _brushDictionary.Add("lianzi.png", Brush.AliceBlue);
        _brushDictionary.Add("licai.png", Brush.Gold);
        _brushDictionary.Add("paobu.png", Brush.AliceBlue);
        _brushDictionary.Add("peihaizi.png", Brush.Pink);
        _brushDictionary.Add("sheying.png", Brush.SkyBlue);
        _brushDictionary.Add("shuaya.png", Brush.SkyBlue);
        _brushDictionary.Add("tingge.png", Brush.Pink);
        _brushDictionary.Add("weixiao.png", Brush.HotPink);
        _brushDictionary.Add("yingyu.png", Brush.LimeGreen);
        _brushDictionary.Add("zaoqi.png", Brush.RoyalBlue);
        _brushDictionary.Add("zaoshui.png", Brush.Honeydew);
        _brushDictionary.Add("zuofan.png", Brush.Ivory);
    }

    public Brush IconNameToBrush(string iconName) {
        return _brushDictionary[iconName];
    }

}