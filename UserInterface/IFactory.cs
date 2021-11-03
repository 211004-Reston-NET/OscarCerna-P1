namespace UserInterface
{
    public interface IFactory
    {
        /// <summary>
        /// Will give a child class from IMenu Interface base on enum MenuType
        /// </summary>
        /// <param name="p_menu">Will determine what menu will be created</param>
        /// <returns>returns a child class from IMenu</returns>
        IMenu GetMenu(MenuType p_menu);
    }
}