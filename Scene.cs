namespace App
{
    public abstract class Scene
    {
        public abstract void Draw (Stack<Scene> stack);
    }
}