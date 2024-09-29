import { useState } from "react";
import $api from "../http";
import { Todo, User } from "../models";

interface AddTodoButtonProps {
  user: User;
}

const AddTodoButton: React.FC<AddTodoButtonProps> = ({ user }) => {
  const [todoTitle, setTodoTitle] = useState("");

  const addTodo = async () => {
    try {
      const newTodo = {
        title: todoTitle,
        userId: user.id,
        deadline: new Date().toISOString(),
      };

      const response = await $api.post<Todo>("/api/todo", newTodo);
      user.todos = [...user.todos, response.data];
    } catch (err) {
      console.error("Todo craete error ", err);
    }
  };

  return (
    <div className="flex w-full items-center justify-between space-x-4">
      <input
        onChange={(e) => setTodoTitle(e.target.value)}
        type="text"
        placeholder="Todo title"
        className="input input-sm input-bordered w-full"
      />
      <button className="btn btn-primary btn-sm w-36" onClick={addTodo}>
        Add todo
      </button>
    </div>
  );
};

export default AddTodoButton;
