using System;

namespace DelegateByMosh
{
    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }
        public void Save()
        {

        }
    }
    public class PhotoProcessor
    {
        public delegate void PhotoFilterHandler(Photo photo);

        public void Process(string path ,PhotoFilterHandler photoFilterHandler)
        {
            var photo = Photo.Load(path);
            photoFilterHandler(photo);
            photo.Save();
        }
    }
    public class PhotoFilter
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply photo brightness");
        }
        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply photo contrast");

        }
        public void Resize(Photo photo)
        {
            Console.WriteLine("Resize photo");

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //System.Action<> // pointer to a method that return void

            //System.Func<> // points to a method that return value 

            //Predicate<> //Special case from func that return bool if object meets the criteria

            var photoFilter = new PhotoFilter();

            PhotoProcessor.PhotoFilterHandler photoFilterHandler = photoFilter.ApplyBrightness;
            photoFilterHandler += photoFilter.ApplyContrast;
            photoFilterHandler += RemoveNoises;


            var photoProcessor = new PhotoProcessor();
            photoProcessor.Process("image.png", photoFilterHandler);

        }
        static void RemoveNoises(Photo photo)
        {
            Console.WriteLine("Remove noises of photo");
        }
    }
}
