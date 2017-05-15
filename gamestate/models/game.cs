using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gamestate.models
{
    public class Game
    {
        public string Title { get; set; }
        public string Coverimage { get; set; }
        public string Sourse { get; set; }
    }

    public class GroupInfoList : List<object>
    {
        public object Key { get; set; }
    }

    public class Gamemanager
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "扫雷经典版", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14915443648101.jpg", Sourse = "http://yx.h5uc.com/saoleijingdianban/" });
            Games.Add(new Game { Title = "巨魔扫雷", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14915442467763.jpg", Sourse = "http://yx.h5uc.com/jumosaolei/" });
            Games.Add(new Game { Title = "海上扫雷", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14915439294999.jpg", Sourse = "http://yx.h5uc.com/haishangsaolei/" });
            Games.Add(new Game { Title = "小羊快跑", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/10/14448903637299.jpg", Sourse = "http://yx.h5uc.com/xiaoyangkuaipao/" });
            Games.Add(new Game { Title = "爱就块一起", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14864370795052.jpg", Sourse = "http://yx.h5uc.com/ajkyq/" });
            Games.Add(new Game { Title = "拯救失足小动物", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14914477931874.jpg", Sourse = "http://yx.h5uc.com/zhengjiushizuxiaodongwu/" });
            Games.Add(new Game { Title = "公主做蛋糕", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14914665643976.jpg", Sourse = "http://yx.h5uc.com/gongzhuzuodangao/" });
            Games.Add(new Game { Title = "能量电路", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14913620138265.jpg", Sourse = "http://yx.h5uc.com/nengliangdianlu/" });
            Games.Add(new Game { Title = "海绵宝宝生病了", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14910187594187.jpg", Sourse = "http://yx.h5uc.com/haimianbaobao/" });
            Games.Add(new Game { Title = "忍者切水果", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/09/14431629179085.jpg", Sourse = "http://yx.h5uc.com/kuangreqieshuiguo/" });
            Games.Add(new Game { Title = "跳天梯", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/08/14410058318096.png", Sourse = "http://yx.h5uc.com/tiaotianti/" });
            Games.Add(new Game { Title = "方块求合体", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14908425059237.jpg", Sourse = "http://yx.h5uc.com/fangkuaiqiujheti/" });
            Games.Add(new Game { Title = "螃蟹救小鱼", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14906694254399.jpg", Sourse = "http://yx.h5uc.com/pangxiejiuxiaoyuer/" });
            Games.Add(new Game { Title = "发泄球", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14905836829580.jpg", Sourse = "http://yx.h5uc.com/faxieqiu/" });
            Games.Add(new Game { Title = "小黄宝贝回家记", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14882503168874.jpg", Sourse = "http://yx.h5uc.com/danggaobaobeihuijiaji/" });
            Games.Add(new Game { Title = "东京购物狂", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14885093477620.jpg", Sourse = "http://yx.h5uc.com/tokyo/" });
            Games.Add(new Game { Title = "兔子跳跳跳", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14903221267969.jpg", Sourse = "http://yx.h5uc.com/tuzitiaotiaotiao/" });
            Games.Add(new Game { Title = "球球相撞", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14901534342710.jpg", Sourse = "http://yx.h5uc.com/qiuqiuxiangzhuang/" });
            Games.Add(new Game { Title = "智障鳄鱼", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14900672394825.jpg", Sourse = "http://yx.h5uc.com/zhizhangeyu/" });
            Games.Add(new Game { Title = "乐高积木消除", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14899779307025.jpg", Sourse = "http://yx.h5uc.com/legaojimudaxiaochu/" });
            Games.Add(new Game { Title = "暴走街篮", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14896350611628.jpg", Sourse = "http://yx.h5uc.com/baozoujielan/" });
            Games.Add(new Game { Title = "忍者大乱斗", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14895474766296.jpg", Sourse = "http://yx.h5uc.com/renzhedaluandou/" });
            Games.Add(new Game { Title = "空间大爆炸", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14894622048968.jpg", Sourse = "http://yx.h5uc.com/kongjiandabaozha/" });
            Games.Add(new Game { Title = "快刀切僵尸", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14891146265455.jpg", Sourse = "http://yx.h5uc.com/kuaidaoqiejiangshi/" });
            return Games;
        }
    }
    public class Gamemanager5
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "扫雷经典版", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/04/14915443648101.jpg", Sourse = "http://yx.h5uc.com/saoleijingdianban/" });
            Games.Add(new Game { Title = "会变长的猫", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14872135661747.jpg", Sourse = "http://yx.h5uc.com/huibianchangdemao/" });
            Games.Add(new Game { Title = "迷宫小球拼图", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14840201256971.jpg", Sourse = "http://yx.h5uc.com/PuzzleBall/" });
            Games.Add(new Game { Title = "教你做西餐", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14307092604042.jpg", Sourse = "http://yx.h5uc.com/Cooking/" });
            Games.Add(new Game { Title = "史上最坑爹的游戏8", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14843018374693.jpg", Sourse = "http://yx.h5uc.com/ProductGame/sszkdyx8/" });
            return Games;
        }
    }
    public class Gamemanager6
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "萌姬无双2", Coverimage = "http://img4.18183.com/h5/allimg/170401/3-1F4011043470-L.jpg", Sourse = "http://yx.h5uc.com/saoleijingdianban/" });
            Games.Add(new Game { Title = "樱桃小丸子", Coverimage = "http://img4.18183.com/h5/allimg/170329/3-1F3291FK80-L.jpg", Sourse = "http://yx.h5uc.com/huibianchangdemao/" });
            Games.Add(new Game { Title = "百姬妖传", Coverimage = "http://img4.18183.com/h5/allimg/170417/3-1F41G053030-L.jpg", Sourse = "http://yx.h5uc.com/PuzzleBall/" });
            Games.Add(new Game { Title = "王者荣耀本命英雄", Coverimage = "http://img4.18183.com/h5/allimg/170411/3-1F4111054180-L.jpg", Sourse = "http://yx.h5uc.com/Cooking/" });
            return Games;
        }
    }
    public class Gamemanager2
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "变色兔无尽奔跑", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14851673493048.jpg", Sourse = "http://yx.h5uc.com/biansetupaoku/" });
            Games.Add(new Game { Title = "大头贪吃蛇", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14850567646685.jpg", Sourse = "http://yx.h5uc.com/datoutanchishe/" });
            Games.Add(new Game { Title = "小小热狗店", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14847973529193.jpg", Sourse = "http://yx.h5uc.com/xiaoxiaoregoudian/" });
            Games.Add(new Game { Title = "美女大盗", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14847943078381.jpg", Sourse = "http://yx.h5uc.com/meinvdadao/" });
            Games.Add(new Game { Title = "拇指怪的冒险", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14847091646668.jpg", Sourse = "http://yx.h5uc.com/muzhiguaidemaoxian/" });
            Games.Add(new Game { Title = "欢乐套牛", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14846370648147.jpg", Sourse = "http://tn.uxi.me/bull/dist/?channel=10024" });
            Games.Add(new Game { Title = "傻蛋找茬2", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14845377317958.jpg", Sourse = "http://yx.h5uc.com/shadanlaizhaocha2/" });
            Games.Add(new Game { Title = "糖果来收集", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14842788408785.jpg", Sourse = "http://yx.h5uc.com/tangguolaishouji/" });
            Games.Add(new Game { Title = "精灵皮卡丘", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/08/14715141968615.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90622" });
            Games.Add(new Game { Title = "玄笔录前传", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14843041863158.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90547" });
            Games.Add(new Game { Title = "坦克崛起", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14843035696633.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/91121" });
            Games.Add(new Game { Title = "史上最坑爹的游戏8", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14843018374693.jpg", Sourse = "http://yx.h5uc.com/ProductGame/sszkdyx8/" });
            Games.Add(new Game { Title = "疯狂男孩冒险记", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14841924194050.jpg", Sourse = "http://yx.h5uc.com/fengkuangnanhaimaoxian/" });
            Games.Add(new Game { Title = "太空陨石危机", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14842184917467.jpg", Sourse = "http://yx.h5uc.com/ProductGame/poise/" });
            Games.Add(new Game { Title = "绿小怪回家记", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14841060895116.jpg", Sourse = "http://yx.h5uc.com/lvxiaoguaihuijia/" });
            Games.Add(new Game { Title = "迷宫小球拼图", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14840201256971.jpg", Sourse = "http://yx.h5uc.com/PuzzleBall/" });
            Games.Add(new Game { Title = "堀北真希记忆卡牌", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14891400745043.jpg", Sourse = "http://yx.h5uc.com/juebeizhenxi/" });
            Games.Add(new Game { Title = "魔幻小铅笔", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14890288747798.jpg", Sourse = "http://yx.h5uc.com/mohuanxiaoqiangbi/" });
            Games.Add(new Game { Title = "小胖子的冒险", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14888556711715.jpg", Sourse = "http://yx.h5uc.com/xiaopangzidemaoxian/" });
            Games.Add(new Game { Title = "绿色卫队", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14888817349483.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/89799" });
            Games.Add(new Game { Title = "仙路传奇", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14890490477564.jpg", Sourse = "http://g.ibeargame.com/enter-181?referer=hedantou" });
            Games.Add(new Game { Title = "极限越野7", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14888662231625.jpg", Sourse = "http://yx.h5uc.com/UphillRush/" });
            Games.Add(new Game { Title = "纸杯蛋糕连一连", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14887678001165.jpg", Sourse = "http://yx.h5uc.com/zhibeidangaolianyilian/" });
            Games.Add(new Game { Title = "急速赛车", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14885120404800.jpg", Sourse = "http://yx.h5uc.com/jisusaiche/" });
            return Games;
        }
    }
    public class Gamemanager3
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "丛林收水果", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14839336189581.jpg", Sourse = "http://yx.h5uc.com/conglinzheshoushuiguo/" });
            Games.Add(new Game { Title = "怪物麻将连连看", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14836740877796.jpg", Sourse = "http://yx.h5uc.com/guaiwumajianglianliangkan/" });
            Games.Add(new Game { Title = "Q萌大富翁之白手起家", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14836957498339.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90795" });
            Games.Add(new Game { Title = "莽荒纪", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14836720258366.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90488" });
            Games.Add(new Game { Title = "汤姆猫金吉拉自拍", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14834997752069.jpg", Sourse = "http://yx.h5uc.com/tangmumaojinjilazipai/" });
            Games.Add(new Game { Title = "萌宠成长记", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/01/14834127841610.jpg", Sourse = "http://yx.h5uc.com/mengchongchengzhangji/" });
            Games.Add(new Game { Title = "女探险家夺宝", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/12/14830939902040.jpg", Sourse = "http://yx.h5uc.com/ProductGame/ntxjxb/" });
            Games.Add(new Game { Title = "六角拼拼困难版", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/10/14776442833581.jpg", Sourse = "http://yx.h5uc.com/ProductGame/ljxx" });
            Games.Add(new Game { Title = "老炮儿", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/12/14507734081830.jpg", Sourse = "http://big.1905.com/lpr/game/" });
            Games.Add(new Game { Title = "僵尸三国", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/01/14531963363690.jpg", Sourse = "http://yx.h5uc.com/404/" });
            Games.Add(new Game { Title = "感染僵尸2", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/11/14479869451782.jpg", Sourse = "http://yx.h5uc.com/jiangshiganran/" });
            Games.Add(new Game { Title = "神奇宝贝H5", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/01/14520724055047.jpg", Sourse = "http://yx.h5uc.com/koudaiyaoguai2/" });
            Games.Add(new Game { Title = "不停开箱子", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14308158362274.jpg", Sourse = "http://h5wyx.com/game?post_id=155" });
            Games.Add(new Game { Title = "大黑牛快跑", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14307263219765.jpg", Sourse = "http://h5wyx.com/game?post_id=866" });
            Games.Add(new Game { Title = "海盗战船", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14307222588002.jpg", Sourse = "http://h5wyx.com/game?post_id=879" });
            Games.Add(new Game { Title = "教你做西餐", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14307092604042.jpg", Sourse = "http://yx.h5uc.com/Cooking/" });
            Games.Add(new Game { Title = "金币大作战 ", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/04/14609714229767.jpg", Sourse = "http://mx.duoyi.com/2016/gold/" }); Games.Add(new Game { Title = "萌兽读心术", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14293437128650.gif", Sourse = "http://h5game.youxiduo.com/duxin/" }); Games.Add(new Game { Title = "小飞龙快跑", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14293423711149.gif", Sourse = "http://h5game.youxiduo.com/dragondash/" }); Games.Add(new Game { Title = "堆木头", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14293409278790.png", Sourse = "http://h5game.youxiduo.com/duimutou/" }); Games.Add(new Game { Title = "青蛙跳木桩", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14292618373353.jpg", Sourse = "http://h5wyx.com/game?post_id=837" }); Games.Add(new Game { Title = "果冻摘星星", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14292606855073.jpg", Sourse = "http://m.yjj365.com/games/gdzxx2/index.html" });
            Games.Add(new Game { Title = "牵手好基友", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/03/14274289777441.jpg", Sourse = "http://g.wanh5.com/ct/2015/hjy/" }); Games.Add(new Game { Title = "疯狂的拳头", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/03/14274271021938.jpg", Sourse = "http://g.wanh5.com/wx/fkdqt/" }); Games.Add(new Game { Title = "疯狂迪斯科", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/03/14274258024879.jpg", Sourse = "http://g.wanh5.com/zjl/dscg/" });
            Games.Add(new Game { Title = "早餐时光小店", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14881660447804.jpg", Sourse = "http://yx.h5uc.com/zaocandian/" });
            Games.Add(new Game { Title = "龙之谷消除", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14881831857892.jpg", Sourse = "http://yx.h5uc.com/longzhiguxiaochu/" });
            Games.Add(new Game { Title = "萝莉笑脸消除", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14879070948995.jpg", Sourse = "http://yx.h5uc.com/luolixiaochu/" });
            Games.Add(new Game { Title = "木偶剧场", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14877342513949.jpg", Sourse = "http://yx.h5uc.com/muoujuyuan/" });
            Games.Add(new Game { Title = "康娜萌翻你", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14876690571406.jpg", Sourse = "http://yx.h5uc.com/kangnamengfanni/" });
            Games.Add(new Game { Title = "刀剑乱舞2048", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14876463267765.jpg", Sourse = "http://yx.h5uc.com/daojianluanwu2048/" });
            Games.Add(new Game { Title = "少女H计划2", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14876455261286.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/316" });
            Games.Add(new Game { Title = "艾米丽的家庭餐厅", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14875745634921.jpg", Sourse = "http://yx.h5uc.com/Delicious/" });
            Games.Add(new Game { Title = "方块汽车赛", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14873101235089.jpg", Sourse = "http://yx.h5uc.com/fangkuaiqichesai/" });
            Games.Add(new Game { Title = "会变长的猫", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14872135661747.jpg", Sourse = "http://yx.h5uc.com/huibianchangdemao/" });
            Games.Add(new Game { Title = "刀剑乱舞测试", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/11/14785761682360.jpg", Sourse = "http://yx.h5uc.com/daojianluanwuceshi/" });
            Games.Add(new Game { Title = "蜀山世界", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/03/14897159018132.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/91198" });
            Games.Add(new Game { Title = "迷你高尔夫世界", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14870408783700.jpg", Sourse = "http://yx.h5uc.com/minigaoerfu/" });
            Games.Add(new Game { Title = "人渣的本愿", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14870662373103.jpg", Sourse = "http://yx.h5uc.com/renzhadebenyuan/" });
            Games.Add(new Game { Title = "小怪吃食物", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14869566861377.jpg", Sourse = "http://yx.h5uc.com/xiaoguaichishiwu/" });
            Games.Add(new Game { Title = "宝石疯狂消消乐", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14866976169542.jpg", Sourse = "http://yx.h5uc.com/baoshifengkuanxiaoxiaole/" });
            Games.Add(new Game { Title = "寻找人间胸器", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14866102552604.jpg", Sourse = "http://yx.h5uc.com/rjxq/" });
            Games.Add(new Game { Title = "命悬一线", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14861778451972.jpg", Sourse = "http://yx.h5uc.com/mxyx/" });
            Games.Add(new Game { Title = "疯狂优诺", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14861170193303.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90835" });
            Games.Add(new Game { Title = "大坦克", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14861167744138.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90027" });
            Games.Add(new Game { Title = "勇者斗魔龙", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/12/14816248606064.jpg", Sourse = "http://api.egret-labs.org/v2/game/11054/90827" });
            Games.Add(new Game { Title = "三生三世大测试", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2017/02/14861150182456.jpg", Sourse = "http://yx.h5uc.com/sanshengsanshi/" });
            Games.Add(new Game { Title = "迪诺小恐龙", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2016/12/14830934114930.jpg", Sourse = "http://yx.h5uc.com/ProductGame/dnxkl/" });
            return Games;
        }
    }
    public class Gamemanager4
    {
        public static List<Game> GetGames()
        {
            var Games = new List<Game>();
            Games.Add(new Game { Title = "贪吃蛇", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14307040741392.jpg", Sourse = "data:text/html,chromewebdata" });
            Games.Add(new Game { Title = "石器大营救", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14305389743555.jpg", Sourse = "http://yx.h5uc.com/shiqidayingjiu/" });
            Games.Add(new Game { Title = "我要吃萝卜", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14305364087223.jpg", Sourse = "http://yx.h5uc.com/CarrotCrave/" }); Games.Add(new Game { Title = "空天大盗", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14304484802918.jpg", Sourse = "http://yx.h5uc.com/Captain-rogers/" }); Games.Add(new Game { Title = "乔治队长", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14304473739148.jpg", Sourse = "http://yx.h5uc.com/X-Type2/" }); Games.Add(new Game { Title = "烧死虫子", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14304469296165.jpg", Sourse = "http://yx.h5uc.com/Bugzburn/" }); Games.Add(new Game { Title = "泡泡", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/05/14304464088513.jpg", Sourse = "http://yx.h5uc.com/Bubble_pop/" }); Games.Add(new Game { Title = "草莓虫", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14303825592559.jpg", Sourse = "http://yx.h5uc.com/BerryBug/" }); Games.Add(new Game { Title = "蜜蜂的浪漫2", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14303808279917.jpg", Sourse = "http://yx.h5uc.com/BeeRomance2/" }); Games.Add(new Game { Title = "疯狂的球", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14303790274313.jpg", Sourse = "http://yx.h5uc.com/Battytheball/" }); Games.Add(new Game { Title = "大海战", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302911687885.jpg", Sourse = "http://yx.h5uc.com/BatailleNavale/" }); Games.Add(new Game { Title = "忍者跑酷", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302898363221.jpg", Sourse = "http://yx.h5uc.com/BanditBlitz/" }); Games.Add(new Game { Title = "一笔连珠", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302887699607.jpg", Sourse = "http://yx.h5uc.com/AquaLabyrinth/" }); Games.Add(new Game { Title = "9球链接", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302874257450.jpg", Sourse = "http://yx.h5uc.com/9Balljs/" }); Games.Add(new Game { Title = "大头十三水", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302152085290.png", Sourse = "http://www.fz222.com/api/login?gid=5" }); Games.Add(new Game { Title = "星球防卫战", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14302005172411.jpg", Sourse = "http://h5wyx.com/game?post_id=748" }); Games.Add(new Game { Title = "相扑吃寿司", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14301925316129.jpg", Sourse = "http://h5wyx.com/game?post_id=730" }); Games.Add(new Game { Title = "地牢骑士", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14301901095828.jpg", Sourse = "http://h5wyx.com/game?post_id=33" }); Games.Add(new Game { Title = "蛇形迷宫", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14301061767681.jpg", Sourse = "http://h5wyx.com/game?post_id=734" }); Games.Add(new Game { Title = "小恐龙突围", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14301047332950.jpg", Sourse = "http://h5wyx.com/game?post_id=858" }); Games.Add(new Game { Title = "疯狂打企鹅", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14299297366021.gif", Sourse = "http://h5game.youxiduo.com/penguin/" }); Games.Add(new Game { Title = "能打多少次", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14299289936921.gif", Sourse = "http://h5game.youxiduo.com/infinihit/" }); Games.Add(new Game { Title = "骑士的宝藏", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14298704691071.jpg", Sourse = "http://yx.h5uc.com/KnightTreasure/index.html" }); Games.Add(new Game { Title = "穿越洞穴", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14298655346906.jpg", Sourse = "http://yx.h5uc.com/ThroughtheCave/" }); Games.Add(new Game { Title = "路西法飞机大战", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296899476301.jpg", Sourse = "http://h5.static.myappgame.com/lxffjdz/index.html" }); Games.Add(new Game { Title = "影子传说", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296882954715.jpg", Sourse = "http://h5.static.myappgame.com/yzcss/index.html" }); Games.Add(new Game { Title = "生死忍者", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296844549780.jpg", Sourse = "http://h5.static.myappgame.com/ssrz/index.html" }); Games.Add(new Game { Title = "火线指令", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296815159846.jpg", Sourse = "http://h5.static.myappgame.com/flowgo/index.html" }); Games.Add(new Game { Title = "疯狂拍大胸", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296745957207.jpg", Sourse = "http://h5.static.myappgame.com/fkpdx/index.html" }); Games.Add(new Game { Title = "采集阳光", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296096812318.jpg", Sourse = "http://h5.static.myappgame.com/sjyg/index.html" }); Games.Add(new Game { Title = "DIY冰淇淋", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296088217541.jpg", Sourse = "http://yx.h5uc.com/bingqiling/" }); Games.Add(new Game { Title = "终极平衡挑战", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296084675828.jpg", Sourse = "http://h5.static.myappgame.com/gxzjtz/index.html" }); Games.Add(new Game { Title = "米娅军训营", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296080186708.jpg", Sourse = "http://h5.static.myappgame.com/myjxy/index.html" }); Games.Add(new Game { Title = "狗狗过桥", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14296043803383.jpg", Sourse = "http://h5.static.myappgame.com/xbycgzg/index.html" }); Games.Add(new Game { Title = "开心足球", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295870089883.jpg", Sourse = "http://h5game.youxiduo.com/soccermover/" }); Games.Add(new Game { Title = "飞跃天空之城", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295245479237.jpg", Sourse = "http://h5game.youxiduo.com/fytkzc/" }); Games.Add(new Game { Title = "一笔画", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295144807806.jpg", Sourse = "http://h5game.youxiduo.com/yibihua/" }); Games.Add(new Game { Title = "美女来找茬", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295139257305.jpg", Sourse = "http://yx.h5uc.com/yxngmrg/" }); Games.Add(new Game { Title = "冰桶挑战", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295127532384.jpg", Sourse = "http://h5game.youxiduo.com/bingtong/" }); Games.Add(new Game { Title = "俄罗斯方块", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295115785564.jpg", Sourse = "http://yx.h5uc.com/eluosifangkuai/" }); Games.Add(new Game { Title = "你是我的小苹果", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295104885377.jpg", Sourse = "http://h5game.youxiduo.com/smallapple/" }); Games.Add(new Game { Title = "我跳我跳", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295097093827.jpg", Sourse = "http://h5game.youxiduo.com/wotiao/" }); Games.Add(new Game { Title = "3D熊出没", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295085271675.jpg", Sourse = "http://h5game.youxiduo.com/xiongchumo/" }); Games.Add(new Game { Title = "激射神经猫", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14295007913525.jpg", Sourse = "http://h5game.youxiduo.com/hitcat/" }); Games.Add(new Game { Title = "制造摩天大楼", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/10/14448985543646.jpg", Sourse = "http://h5game.youxiduo.com/mtdl/" }); Games.Add(new Game { Title = "放开那猫咪", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14294107895200.gif", Sourse = "http://h5game.youxiduo.com/unlockcat/" }); Games.Add(new Game { Title = "重力落积木", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14294100066713.gif", Sourse = "http://h5game.youxiduo.com/jiaoben1144/" }); Games.Add(new Game { Title = "21点", Coverimage = "http://img4.18183.com/h5uc2015/uploads/image/2015/04/14294077633344.gif", Sourse = "http://g.wanh5.com/wx/21dian/?f=1013" });
            return Games;
        }
    }
}