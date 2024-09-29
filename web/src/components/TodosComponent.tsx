import { User } from "../models";
import AddTodoButton from "./AddTodoButton";

interface TodosComponentProps {
  user: User;
}

const TodosComponent: React.FC<TodosComponentProps> = ({ user }) => {
  return (
    <div className="space-y-3">
      {user.todos && user.todos.length > 0 ? (
        <ul>
          {user.todos.map((todo) => (
            <li key={todo.id}>{todo.title}</li>
          ))}
        </ul>
      ) : (
        <p>No tasks available.</p>
      )}
      <AddTodoButton user={user} />
    </div>
  );
};

export default TodosComponent;
