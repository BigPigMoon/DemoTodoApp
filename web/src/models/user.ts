import { Todo } from "./todo"

export interface User {
    id: string
    nickname: string
    createdAt: string
    todos: Todo[]
}