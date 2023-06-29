namespace SunGameStudio.Humanoid
{
    public class FireButton : PlayerActionButton
    {
        protected override void Act() => 
            _mediator.PlayerShoot();
    }
}


