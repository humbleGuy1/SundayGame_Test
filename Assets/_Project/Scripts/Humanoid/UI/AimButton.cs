namespace SunGameStudio.Humanoid
{
    public class AimButton : PlayerActionButton
    {
        protected override void Act() => 
            _mediator.SwitchAim();
    }
}


