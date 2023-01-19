namespace PitneyBowesQuestFG.Repository_Service;

public interface IEntity<T>
{
    public T Id { get; set; }   
}