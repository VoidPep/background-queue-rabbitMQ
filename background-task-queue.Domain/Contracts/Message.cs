namespace background_task_queue.Domain.Contracts;

public record Message(string Value, DateTime SentDate);