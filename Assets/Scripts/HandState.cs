using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandState {

    Material Hands = (Material)Resources.Load("Hands", typeof(Material));
    enum State { dirty, clean, gloved }
    State _state = State.dirty;

    Color glove_color = Color.yellow;
    Color clean_color = Color.white;
    Color dirty_color = Color.grey;

    public void clean(){
        if (_state == State.gloved) return;
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
        _state = State.clean;
        Hands.color = glove_color;
    }

    public void unglove()
    {
        if (_state != State.gloved) return;
        _state = State.dirty;
        Hands.color = dirty_color;
    }
}
