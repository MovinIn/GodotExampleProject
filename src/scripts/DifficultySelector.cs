using Godot;
using System;

public partial class DifficultySelector : VBoxContainer
{
	// Called when the node enters the scene tree for the first time.
	CheckButton easyBtn,mediumBtn,hardBtn;
	Difficulty difficulty;
	public override void _Ready()
	{
		easyBtn=GetNode<CheckButton>("Easy");
		mediumBtn=GetNode<CheckButton>("Medium");
		hardBtn=GetNode<CheckButton>("Hard");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void onEasyToggled(bool toggledOn){
		if(!toggledOn){
			easyBtn.SetPressedNoSignal(true);
			return;
		}
		playSound();
		difficulty=Difficulty.EASY;
		easyBtn.SetPressedNoSignal(true);
		mediumBtn.SetPressedNoSignal(false);
		hardBtn.SetPressedNoSignal(false);
	}
	public void onMediumToggled(bool toggledOn){
		if(!toggledOn){
			onEasyToggled(true);
			return;
		}
		playSound();
		difficulty=Difficulty.MEDIUM;
		easyBtn.SetPressedNoSignal(false);
		hardBtn.SetPressedNoSignal(false);
	}
	public void onHardToggled(bool toggledOn){
		if(!toggledOn){
			onEasyToggled(true);
			return;
		}
		playSound();
		difficulty=Difficulty.HARD;
		easyBtn.SetPressedNoSignal(false);
		mediumBtn.SetPressedNoSignal(false);
	}

	private void playSound(){
		Menu.soundManager.playSound(Sound.CHANGE_DIFFICULTY,-10f,1);
	}

	public Difficulty getDifficulty(){
		return difficulty;
	}
}
