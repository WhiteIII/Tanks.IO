using System.Collections.Generic;

public class GunScriptsList
{
    public Dictionary<GunType, IGunFactory> GunsFactoryList { get; private set; } = new Dictionary<GunType, IGunFactory>();

    private OrdinaryGunFactory _ordinaryGun = new OrdinaryGunFactory();
    private DoubleShotFactory _doubleShotGun = new DoubleShotFactory();
    private SniperGunFactory _sniperGun = new SniperGunFactory();
    private SpeedsterFactoty _speedsterGun = new SpeedsterFactoty();
    private MachineGunFectory _machineGun = new MachineGunFectory();
    private TripleShotFactory _tripleShotGun = new TripleShotFactory();
    private QuadroShotFactory _quadroShotGun = new QuadroShotFactory();
    private FourSidesFactory _fourSidesGun = new FourSidesFactory();
    private TriplesterFactory _triplesterGun = new TriplesterFactory();
    private TripletFactory _tripletGun = new TripletFactory();
    private PentaShotFactory _pentaShotGun = new PentaShotFactory();
    private OctoFactory _octoGun = new OctoFactory();
    private HexadShotFactory _hexadShotGun = new HexadShotFactory();
    private DestroyerFactory _destroyerGun = new DestroyerFactory();

    public GunScriptsList() 
    {
        GunsFactoryList.Add(_ordinaryGun.GunType, _ordinaryGun);
        GunsFactoryList.Add(_doubleShotGun.GunType, _doubleShotGun);
        GunsFactoryList.Add(_sniperGun.GunType, _sniperGun);
        GunsFactoryList.Add(_speedsterGun.GunType, _speedsterGun);
        GunsFactoryList.Add(_machineGun.GunType, _machineGun);
        GunsFactoryList.Add(_tripleShotGun.GunType, _tripleShotGun);
        GunsFactoryList.Add(_quadroShotGun.GunType, _quadroShotGun);
        GunsFactoryList.Add(_fourSidesGun.GunType, _fourSidesGun);
        GunsFactoryList.Add(_triplesterGun.GunType, _triplesterGun);
        GunsFactoryList.Add(_tripletGun.GunType, _tripletGun);
        GunsFactoryList.Add(_pentaShotGun.GunType, _pentaShotGun);
        GunsFactoryList.Add(_octoGun.GunType, _octoGun);
        GunsFactoryList.Add(_hexadShotGun.GunType, _hexadShotGun);
        GunsFactoryList.Add(_destroyerGun.GunType, _destroyerGun);
    }
}
