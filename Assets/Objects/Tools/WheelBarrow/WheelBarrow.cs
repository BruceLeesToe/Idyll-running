using Godot;
using System;

public partial class WheelBarrow : Item
{
	[Export] public float speedTrigger = 1;
	[Export] public GpuParticles3D particles;
	public Vector3 previousPosition = new Vector3(0, 0, 0);
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
	}

	new public virtual void Activate() {
		active = true;
		particles.Visible = true;
	}
	new public virtual void Deactivate() {
		active = false;
		particles.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		// GD.Print(global.Length());
		if ((previousPosition - GlobalPosition).Length()*30 >= speedTrigger) {
			Activate();
		} else {
			Deactivate();
		}
		previousPosition = GlobalPosition;
		// particles.Visible = active;
	}
}
