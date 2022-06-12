using System;

namespace BigPardakht.DynamicForm
{
    public class Input:Attribute
    {
        public InputType Type { get; set; }
    }

    public enum InputType
    {
        Text,
        TextArea,
        Number,
        Hidden,
        Select,
        Checkbox,
        Radio
    }
}