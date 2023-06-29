namespace SunGameStudio.Humanoid
{
    public class JumpButton : PlayerActionButton
    {
        protected override void Act() => 
            _mediator.PlayerJump();
    }
}


