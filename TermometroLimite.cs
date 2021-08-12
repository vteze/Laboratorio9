public class TermometroLimite : Termometro
{
    public delegate void MeuDelegate (string msg);
    public event MeuDelegate LimiteSuperiorEvent;
    public event MeuDelegate TempVoltouNormal;
    private double limiteSuperior;
    private bool disparadoEventoLimiteSuperior;
    public TermometroLimite (double ls)
    {
        limiteSuperior = ls;
        disparadoEventoLimiteSuperior = false;
    }
    public double LimiteSuperior
    {
        get { return limiteSuperior; }
        set { limiteSuperior = value; }
    }
    private void OnLimiteSuperiorEvent()
    {
        if ((this.Temperatura > limiteSuperior) && (!disparadoEventoLimiteSuperior))
        {
            if (LimiteSuperiorEvent != null)
            {
                LimiteSuperiorEvent($"Atenção, temperatura {this.Temperatura - limiteSuperior} graus acima do limite!!");
                disparadoEventoLimiteSuperior = true;   
            }
        }
    }
    private void OnTempVoltouNormalEvent()
    {
        if ((this.Temperatura <= limiteSuperior) && (disparadoEventoLimiteSuperior))
        {
            if (TempVoltouNormal != null)
            {
                TempVoltouNormal($"A temperatura voltou ao normal para {this.Temperatura} graus");
                disparadoEventoLimiteSuperior = false;
            }
        }
    }

    public override void Aumentar()
    {
        base.Aumentar();
        OnLimiteSuperiorEvent();
    }
    public override void Aumentar(double quantia)
    {
        base.Aumentar(quantia);
        OnLimiteSuperiorEvent();
    }
    public override void Diminuir()
    {
        base.Diminuir();
        OnTempVoltouNormalEvent();
    }
    public override void Diminuir(double quantia)
    {
        base.Diminuir(quantia);
        OnTempVoltouNormalEvent();
    }
}