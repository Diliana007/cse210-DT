using System;
using System.Threading.Tasks.Dataflow;

class Job
{
    public string _jobTitle { get; set; }
    public string _company { get; set; }
    public int _startYear { get; set; }
    public int _endYear { get; set; }
}

class Resume
{
    public string _name { get; set; }
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            Console.WriteLine($"{job._jobTitle}, ({job._company}) {job._startYear}-{job._endYear}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        Resume myResume = new Resume();
        myResume._name = "Allison Rose";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        myResume.Display();
    }
}