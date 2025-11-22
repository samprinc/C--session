
// --- OOP CONCEPTS DEMONSTRATION ---
// This code illustrates the four main concepts of  
// Object-Oriented Programming (OOP):
// 1. Class - The Blueprint 
// 2. Attributes (Properties)/Characteristics
// 3. Methods/Actions
// 4. Constructor/Initialization
// 5. Polymorphism - Method Overriding
// 6. Inheritance/Derivation/Subclassing
// 7. Encapsulation/Data Hiding/Access Control
// 8. Objects (Instances)/Instantiation/Creation/Usage/Utilization/Interaction
//    Manipulation /Operation   





// --- 1. CLASS (The Blueprint) ---
// This is the base class or "parent" class.
public class Student
{
    // --- 2. ATTRIBUTES (Properties)/  ---
    // These are the characteristics. 
    // We use properties for ENCAPSULATION.

    // This 'Name' property can be read by anyone, but only set
    // by code within this class (or child classes).
    public string Name { get; protected set; }

    // This 'StudentID' can be read by anyone, but can ONLY
    // be set when the object is first created (in the constructor).
    public string StudentID { get; private set; }

    // This is a private "backing field" for the grade.
    // It is fully ENCAPSULATED. No one outside this class can see it.
    private int _grade;

    // --- 3. CONSTRUCTOR ---
    // This special method is called when a new object is created.
    // It's used to set up the initial state (the attributes).
    public Student(string name, string studentID)
    {
        Name = name;
        StudentID = studentID;
        _grade = 0; // Default grade
        Console.WriteLine($"A new Student object was created! Name: {Name}");
    }

    // --- 4. METHODS (The Actions) ---

    // This is a public method to safely change the private '_grade' field.
    // This is a key part of ENCAPSULATION.
    public void SubmitAssignment(int score)
    {
        if (score >= 0 && score <= 100)
        {
            _grade = score;
            Console.WriteLine($"{Name} submitted an assignment and got {score}%.");
        }
        else
        {
            Console.WriteLine("Invalid score.");
        }
    }

    // This is a public method to safely READ the private '_grade' field.
    public int GetCurrentGrade()
    {
        return _grade;
    }

    // --- 5. POLYMORPHISM (Method to be Overridden) ---
    // We use the 'virtual' keyword to allow child classes
    // to "override" this method with their own version.
    public virtual void Study()
    {
        // This is the default action
        Console.WriteLine($"{Name} is studying... general subjects.");
    }
}

// --- 6. INHERITANCE (The Child Class) ---
// 'ScienceStudent' "is-a" 'Student'. It inherits all of
// Student's public and protected properties and methods.
public class ScienceStudent : Student
{
    public string LabSection { get; set; }

    // The constructor for the child class.
    // It uses ': base(name, studentID)' to call the PARENT'S constructor.
    // This is required.
    public ScienceStudent(string name, string studentID, string labSection) 
        : base(name, studentID)
    {
        LabSection = labSection;
    }

    // --- 7. POLYMORPHISM (Overriding the Method) ---
    // We use the 'override' keyword to provide a NEW version
    // of the 'Study' method just for ScienceStudents.
    public override void Study()
    {
        Console.WriteLine($"{Name} is studying by conducting experiments in {LabSection}.");
    }
}

// --- INHERITANCE (Another Child Class) ---
public class ArtStudent : Student
{
    public string StudioProject { get; set; }

    // Constructor, calling the base (Student) constructor
    public ArtStudent(string name, string studentID, string studioProject) 
        : base(name, studentID)
    {
        StudioProject = studioProject;
    }

    // POLYMORPHISM: Overriding 'Study' with a different action
    public override void Study()
    {
        Console.WriteLine($"{Name} is studying by painting {StudioProject}.");
    }
}

// --- This is the main part of your program that runs ---
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Creating Objects ---");
        
        // --- 8. OBJECTS (The Instances) ---
        // We are "instantiating" objects from our blueprints (classes).
        
        // This object is type 'Student'
        Student student1 = new Student("Ben", "S123"); 
        
        // This object is type 'ScienceStudent'
        ScienceStudent student2 = new ScienceStudent("Sarah", "S456", "Lab A");
        
        // This object is type 'ArtStudent'
        ArtStudent student3 = new ArtStudent("Mike", "S789", "the landscape");
        
        Console.WriteLine("\n--- Demonstrating Encapsulation ---");
        
        // We can't access the private field directly:
        // student1._grade = 90; // This will cause an ERROR!
        
        // We must use the public methods to interact with the data:
        student1.SubmitAssignment(85);
        Console.WriteLine($"{student1.Name}'s grade is {student1.GetCurrentGrade()}");
        
        
        Console.WriteLine("\n ---Demonstrating Polymorphism--------");
        
        // This is the most important part!
        // We create a List that holds the PARENT type (Student).
        List<Student> studentList = new List<Student>();

        // We can add all the different KINDS of students
        // because they are ALL "Students" (thanks to inheritance).
        studentList.Add(student1); // Student
        studentList.Add(student2); // ScienceStudent
        studentList.Add(student3); // ArtStudent
        
        // Now, we loop through the list and call the SAME method...
        foreach (Student s in studentList)
        {
            // ...but C# runs the CORRECT version of Study() 
            // for each object's *actual* type.
            // This is Polymorphism in action!
            s.Study();
        }
    }
}