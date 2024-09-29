import $api from "../http";
import { User } from "../models";

interface RemoveUserButtonProps {
  userData: User[];
  setUserData: (data: User[]) => void;
  userId: string;
}

const RemoveUserButton: React.FC<RemoveUserButtonProps> = ({
  userData,
  setUserData,
  userId,
}) => {
  const removeUser = async (id: string) => {
    try {
      await $api.delete(`/api/user/${id}`);

      setUserData(userData.filter((u: User) => u.id !== id));
    } catch (err) {
      console.error("User remove error: ", err);
    }
  };

  return (
    <button
      className="btn btn-error w-36"
      onClick={async () => await removeUser(userId)}
    >
      Delete user
    </button>
  );
};

export default RemoveUserButton;
