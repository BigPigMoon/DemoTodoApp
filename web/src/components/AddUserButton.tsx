import { useState } from "react";
import $api from "../http";
import { User } from "../models";

interface AddUserButtonProps {
  userData: User[];
  setUserData: (data: User[]) => void;
}

const AddUserButton: React.FC<AddUserButtonProps> = ({
  userData,
  setUserData,
}) => {
  const [nickname, setNickname] = useState("");

  const createUser = async () => {
    if (nickname.trim() !== "") {
      try {
        const respose = await $api.post<User>("/api/user", {
          nickname,
        });

        setUserData([...userData, respose.data]);
        setNickname("");
      } catch (err) {
        console.error("User create error: ", err);
      }
    }
  };

  return (
    <div className="flex space-x-5 w-full px-16">
      <input
        onChange={(e) => setNickname(e.target.value)}
        type="text"
        placeholder="User name"
        className="input input-bordered w-full"
      />
      <button className="btn btn-primary mx-16" onClick={createUser}>
        Add new user
      </button>
    </div>
  );
};

export default AddUserButton;
