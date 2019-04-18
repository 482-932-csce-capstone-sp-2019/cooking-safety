using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState {

    Material Hands = (Material)Resources.Load("Hands", typeof(Material));
    enum State { dirty, soaped, clean, gloved, beef, chicken }
    State _state;

    Color glove_color = Color.yellow;
    Color clean_color = Color.white;
    Color dirty_color = Color.grey;
    Color soapy_color = Color.red;

    public HandState(){
        Hands.color = dirty_color;
        _state = State.dirty;
    }

    public void soap()
    {
        if (_state == State.gloved) return;
        _state = State.soaped;
        Hands.color = soapy_color;
    }

    public void clean(){
        if (_state != State.soaped) return;
        _state = State.clean;
        Hands.color = clean_color;
    }

    public void dirty()
    {
        if (_state == State.gloved) return;
        _state = State.dirty;
        Hands.color = dirty_color;
    }

    public void glove()
    {
        if (_state == State.gloved) return;
        if (_state != State.clean)
		{
			Results.Fail("Put on gloves without washing hands first. FAIL");
			return;
		}
        _state = State.gloved;
        Hands.color = glove_color;
    }

    public void unglove()
    {
        if (_state != State.gloved && _state != State.beef && _state != State.chicken) return;
        _state = State.dirty;
        Hands.color = dirty_color;
    }
	
	public void touch_chicken()
	{    
		if (_state == State.beef)
		{
			Results.Fail("Cross contamination: failed to wash hands between touching meats. FAIL");
			return;
		}
        if (_state != State.gloved && _state != State.chicken)
        {
            Results.Fail("Touched meat with bare hands. FAIL");
            return;
        }
        _state = State.chicken;
	}
	
	public void touch_beef()
	{
		if (_state == State.chicken)
		{
			Results.Fail("Cross contamination: failed to wash hands between touching meats. FAIL");
			return;
		}
        if (_state != State.gloved && _state != State.beef)
        {
            Results.Fail("Touched meat with bare hands. FAIL" + this.to_s());
            return;
        }
        _state = State.beef;
	}
	public void touch_bread()
    {
        if (_state != State.gloved && _state != State.beef && _state != State.chicken)
        {
            Results.Fail("Touched bread with bare hands. FAIL" + this.to_s());
            return;
        }
    }
	public string to_s(){
			return "" + _state;
	}
}
